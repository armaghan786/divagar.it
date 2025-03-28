﻿
(function() {
  const w = window;
  w._$delayHydration = (() => {
    if (!("requestIdleCallback" in w) || !("requestAnimationFrame" in w))
  return new Promise((resolve) => resolve("not supported"));
function eventListeners() {
  const c = new AbortController();
  const p = new Promise((resolve) => {
    const hydrateOnEvents = "mousemove,scroll,keydown,click,touchstart,wheel".split(",");
    function handler(e) {
      hydrateOnEvents.forEach((e2) => w.removeEventListener(e2, handler));
      requestAnimationFrame(() => resolve(e));
    }
    hydrateOnEvents.forEach((e) => {
      w.addEventListener(e, handler, {
        capture: true,
        once: true,
        passive: true,
        signal: c.signal
      });
    });
  });
  return { c: () => c.abort(), p };
}
function idleListener() {
  let id;
  const p = new Promise((resolve) => {
    const isMobile = w.innerWidth < 640;
    const timeout = isMobile ? Number.parseInt("5000") : Number.parseInt("4500");
    const timeoutDelay = () => setTimeout(
      () => requestAnimationFrame(() => resolve("timeout")),
      timeout
    );
    id = w.requestIdleCallback(timeoutDelay, { timeout: Number.parseInt("2000") });
  });
  return { c: () => window.cancelIdleCallback(id), p };
}
const triggers = [idleListener(), eventListeners()];
const hydrationPromise = Promise.race(
  triggers.map((t) => t.p)
).finally(() => {
  triggers.forEach((t) => t.c());
});
return hydrationPromise;
}
  )();
  
  ;(() => {
  w._$delayHydration.then((e) => {
    if (!(e instanceof PointerEvent) && !(e instanceof MouseEvent) && !(e instanceof TouchEvent))
      return;
    if (e instanceof MouseEvent && e.type !== "click")
      return;
    setTimeout(
      () => w.requestIdleCallback(
        () => setTimeout(() => e.target?.click(), 500)
      ),
      50
    );
  });
})();

})();
