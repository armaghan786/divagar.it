// Enum Definitions
const SliderEffect = {
	NONE: "none",
	ELEVATE: "elevate",
	GLOW: "glow"
};

const AnimationEffect = {
	FADE: "fade",
	EASE_IN: "ease-in",
	SLIDE: "slide"
};

// Function to handle slide transformations and animations
function initializeSlider(config) {
	const transformProperty = ""; // To be used for CSS transform property
	const transitionDuration = ""; // To be used for CSS transition duration
	let slideData = config.sliderList || [];

	// Prepare slide data if slide or ease-in effects are used
	if (
		[config.sliderAnimation.animationEffect === AnimationEffect.SLIDE,
		config.sliderAnimation.animationEffect === AnimationEffect.EASE_IN].includes(true) &&
		config.sliderList.length
	) {
		slideData = [
			{
				...config.sliderList[config.sliderList.length - 1],
				id: `cloned-${config.sliderList[config.sliderList.length - 1].id}`
			},
			...config.sliderList,
			{
				...config.sliderList[0],
				id: `cloned-${config.sliderList[0].id}`
			}
		];
	}

	// Function to reset the transition duration
	function resetTransition() {
		setTimeout(() => {
			transitionDuration = "0ms";
		}, 30);
	}

	// Function to handle slide animation
	function handleSlideAnimation(currentIndex, newIndex) {
		if (!config.sliderList || typeof currentIndex === "undefined") return;

		const lastIndex = config.sliderList.length - 1;
		const isLastToFirst = currentIndex === lastIndex && newIndex === 0;
		const isFirstToLast = newIndex === lastIndex && currentIndex === 0;

		let transformValue, durationValue;
		if (isLastToFirst) {
			durationValue = "0ms";
			transformValue = `translateX(-${(newIndex + 2) * 100}%)`;
			setTimeout(() => {
				transitionDuration = "300ms";
				transformProperty = `translateX(-${(newIndex + 1) * 100}%)`;
				resetTransition();
			}, 30);
		} else if (isFirstToLast) {
			durationValue = "0ms";
			transformValue = `translateX(-${newIndex * 100}%)`;
			setTimeout(() => {
				transitionDuration = "300ms";
				transformProperty = `translateX(-${(newIndex + 1) * 100}%)`;
				resetTransition();
			}, 30);
		} else {
			transformValue = `translateX(-${(newIndex + 1) * 100}%)`;
			durationValue = "300ms";
			resetTransition();
		}

		transformProperty = transformValue;
		transitionDuration = durationValue;
	}

	// Function to handle transformations
	function handleTransformation() {
		if (typeof config.currentIndex !== "undefined") {
			transformProperty = `translateX(-${config.currentIndex * 100}%)`;
		}
	}

	return {
		slideData,
		handleSlideAnimation,
		handleTransformation,
		transformProperty,
		transitionDuration
	};
}

// Function to initialize the slider
function initializeCarousel(elementConfig) {
	const borderEnabled = elementConfig.styles.borderWidth > 0;
	let autoAnimationInterval = null;
	let currentIndex = 0;

	const { sliderList, sliderSize, sliderAnimation, sliderPagination, sliderArrow } = elementConfig.extra;

	const { slideData, handleSlideAnimation, handleTransformation, transformProperty, transitionDuration } = initializeSlider({
		sliderAnimation,
		sliderList,
		sliderSize,
		currentIndex
	});

	// Function to move to the next slide
	function moveToNextSlide() {
		if (sliderAnimation.infiniteLoop) {
			currentIndex = (currentIndex + 1) % sliderList.length;
		} else {
			if (currentIndex === sliderList.length - 1) clearAutoAnimation();
			if (currentIndex < sliderList.length - 1) currentIndex += 1;
		}
	}

	// Function to start automatic animation
	function startAutoAnimation() {
		clearAutoAnimation();
		const interval = (sliderAnimation.interval || 3) * 1000;
		autoAnimationInterval = setInterval(moveToNextSlide, interval);
	}

	// Function to clear automatic animation
	function clearAutoAnimation() {
		if (autoAnimationInterval) clearInterval(autoAnimationInterval);
	}

	// Event handlers for pausing and resuming animation on hover
	function handleMouseOver() {
		if (sliderAnimation.pauseOnHover && sliderAnimation.autoAnimationEnable) {
			clearAutoAnimation();
		}
	}

	function handleMouseOut() {
		if (sliderAnimation.pauseOnHover && sliderAnimation.autoAnimationEnable) {
			startAutoAnimation();
		}
	}

	// Function to manually update the current slide
	function updateCurrentSlide(index) {
		currentIndex = index;
	}

	// Initialize the carousel
	if (sliderAnimation.autoAnimationEnable) {
		startAutoAnimation();
	}

	// Return the public API
	return {
		moveToNextSlide,
		startAutoAnimation,
		clearAutoAnimation,
		handleMouseOver,
		handleMouseOut,
		updateCurrentSlide,
		transformProperty,
		transitionDuration
	};
}

// Example of how to use the functions to create a carousel
const myCarouselConfig = {
	element: {
		styles: {
			borderWidth: 1
		},
		extra: {
			sliderList: [{ id: 1, backgroundImage: 'image1.jpg' }, { id: 2, backgroundImage: 'image2.jpg' }],
			sliderSize: 'large',
			sliderAnimation: { animationEffect: AnimationEffect.SLIDE, infiniteLoop: true, autoAnimationEnable: true, pauseOnHover: true, interval: 3 },
			sliderPagination: { enable: true },
			sliderArrow: { enable: true }
		}
	}
};

// Initialize the carousel
const myCarousel = initializeCarousel(myCarouselConfig.element);

// You can now control the carousel using the returned API:
// e.g., myCarousel.moveToNextSlide();
