function formattadatalingua(data, lingua) {
	var ritorno = "";
	var anno=data.substring(data.length-4,data.length);
	var dataSenzaAnno=data.replace("/" + anno,"");
	var mese=data.substring(dataSenzaAnno.lastIndexOf("/")+1, dataSenzaAnno.length);
	var giorno=data.substring(0,dataSenzaAnno.lastIndexOf("/"));
	if (parseInt(giorno)==1) {
		var suffisso="st";
	} else if (parseInt(giorno)==2) {
		var suffisso="nd";
	} else {
		var suffisso="th";
	}
	if (giorno.substring(0,1)==0) {
		giorno=giorno.substring(1,2);
	}
	
	var data=new Date(anno + "/" + mese + "/" + giorno);
	var nomeGiorno=traduciGiorni(data.getDay(), lingua);
	var nomeMese=traduciMesi(mese, lingua);
	if (lingua=="en") {
		ritorno=nomeGiorno + ", " + nomeMese + " " + giorno + suffisso + ", " + anno;
	} else if (lingua=="fr") {
		ritorno=nomeGiorno + " " + giorno + " " + nomeMese + " " + anno;
	} else if (lingua=="de") {
		ritorno=nomeGiorno + ", " + giorno + ". " + nomeMese + " " + anno;
	} else if (lingua=="es") {
		ritorno=" el " + nomeGiorno + " " + giorno + " de " + nomeMese + " de " + anno;
	} else {
		ritorno=nomeGiorno + ", " + giorno + " " + nomeMese + " " + anno;
	};
	
	return ritorno;
}
function traduciGiorni(giorno, lingua) {
var day="";
giorno=parseInt(giorno);
if (lingua=="en") {
	switch (giorno) {
		case 0:
			day = "Sunday";
			break;
		case 1:
			day = "Monday";
			break;
		case 2:
			day = "Tuesday";
			break;
		case 3:
			day = "Wednesday";
			break;
		case 4:
			day = "Thursday";
			break;
		case 5:
			day = "Friday";
			break;
		case 6:
			day = "Saturday";
	} 
} else if (lingua=="fr") {
	switch (giorno) {
		case 0:
			day = "dimanche";
			break;
		case 1:
			day = "lundi";
			break;
		case 2:
			day = "mardi";
			break;
		case 3:
			day = "mercredi";
			break;
		case 4:
			day = "jeudi";
			break;
		case 5:
			day = "vendredi";
			break;
		case 6:
			day = "samedi";
	} 
} else if (lingua=="de") {
	switch (giorno) {
		case 0:
			day = "Sontag";
			break;
		case 1:
			day = "Montag";
			break;
		case 2:
			day = "Dienstag";
			break;
		case 3:
			day = "Mittwoch";
			break;
		case 4:
			day = "Donnerstag";
			break;
		case 5:
			day = "Freitag";
			break;
		case 6:
			day = "Samstag";
	}
} else if (lingua=="es") {
	switch (giorno) {
		case 0:
			day = "domingo";
			break;
		case 1:
			day = "lunes";
			break;
		case 2:
			day = "martes";
			break;
		case 3:
			day = "miércoles"
			break;
		case 4:
			day = "jueves"
			break;
		case 5:
			day = "viernes"
			break;
		case 6:
			day = "sábado";
	}
} else {
	switch (giorno) {
		case 0:
			day = "domenica";
			break;
		case 1:
			day = "lunedì";
			break;
		case 2:
			day = "martedì";
			break;
		case 3:
			day = "mercoledì"
			break;
		case 4:
			day = "giovedì"
			break;
		case 5:
			day = "venerdì"
			break;
		case 6:
			day = "sabato";
	}
}
return day;
}
function traduciMesi(mese, lingua) {
var month="";
mese=parseInt(mese);
if (lingua=="en") {
	switch (mese) {
		case 1:
			month = "January";
			break;
		case 2:
			month = "February";
			break;
		case 3:
			month = "March";
			break;
		case 4:
			month = "April";
			break;
		case 5:
			month = "May";
			break;
		case 6:
			month = "June";
			break;
		case 7:
			month = "July";
			break;
		case 8:
			month = "August";
			break;
		case 9:
			month = "September";
			break;
		case 10:
			month = "October";
			break;
		case 11:
			month = "November";
			break;
		case 12:
			month = "December";
	} 
} else if (lingua=="fr") {
	switch (mese) {
		case 1:
			month = "Janvier";
			break;
		case 2:
			month = "Février";
			break;
		case 3:
			month = "Mars";
			break;
		case 4:
			month = "Avril";
			break;
		case 5:
			month = "Mai";
			break;
		case 6:
			month = "Juin";
			break;
		case 7:
			month = "Juillet";
			break;
		case 8:
			month = "Août";
			break;
		case 9:
			month = "Septembre";
			break;
		case 10:
			month = "Octobre";
			break;
		case 11:
			month = "Novembre";
			break;
		case 12:
			month = "Décembre";
	} 
} else if (lingua=="de") {
	switch (mese) {
		case 1:
			month = "Januar";
			break;
		case 2:
			month = "Februar";
			break;
		case 3:
			month = "März";
			break;
		case 4:
			month = "April";
			break;
		case 5:
			month = "Mai";
			break;
		case 6:
			month = "Juni";
			break;
		case 7:
			month = "Juli";
			break;
		case 8:
			month = "August";
			break;
		case 9:
			month = "September";
			break;
		case 10:
			month = "Oktober";
			break;
		case 11:
			month = "November";
			break;
		case 12:
			month = "Dezember";
	}
} else if (lingua=="es") {
	switch (mese) {
		case 1:
			month = "enero";
			break;
		case 2:
			month = "febrero";
			break;
		case 3:
			month = "marzo";
			break;
		case 4:
			month = "aberil"
			break;
		case 5:
			month = "mayo"
			break;
		case 6:
			month = "junio"
			break;
		case 7:
			month = "julio";
			break;
		case 8:
			month = "agosto";
			break;
		case 9:
			month = "septembre";
			break;
		case 10:
			month = "octubre";
			break;
		case 11:
			month = "noviembre";
			break;
		case 12:
			month = "deciembre";
	}
} else {
	switch (mese) {
		case 1:
			month = "gennaio";
			break;
		case 2:
			month = "febbraio";
			break;
		case 3:
			month = "marzo";
			break;
		case 4:
			month = "aprile"
			break;
		case 5:
			month = "maggio"
			break;
		case 6:
			month = "giugno"
			break;
		case 7:
			month = "luglio";
			break;
		case 8:
			month = "agosto";
			break;
		case 9:
			month = "settembre";
			break;
		case 10:
			month = "ottobre";
			break;
		case 11:
			month = "novembre";
			break;
		case 12:
			month = "dicembre";
	}
}
return month;
}
function formatAMPM(ora, lingua) {
	if (lingua=="en") {
		var hours = ora.substring(0,2);
		var minutes = ora.substring(3,5);
		var ampm = hours >= 12 ? 'pm' : 'am';
		hours = hours % 12;
		hours = hours ? hours : 12; // the hour '0' should be '12'
		var strTime = hours + ':' + minutes + ' ' + ampm;
	} else {
		strTime=ora
	}
	return strTime;
}

function getQString(string, key) {
  var str = string;
  if (!str) {
	return;
  } else {
	str = str.slice(1);
	if (!str) { return;}

	var pairs = str.split(/&|;/);
	var params = {};
	for (var i = 0, cnt = pairs.length; i < cnt; i++) {
	  var p = pairs[i].split('=');
	  var pKey = decodeURIComponent(p[0]);
	  var pValue = p[1]?decodeURIComponent(p[1].replace(/\+/g, ' ')):'';
	  if (params.hasOwnProperty(pKey)) {
		var ex = params[pKey];
		if ($.isArray(ex)) {
		  ex.push(pValue);
		} else {
		  params[pKey] = [ex, pValue];
		}
	  } else {
		params[pKey] = pValue;
	  }
	}
	if (key === undefined) {
	  return params;
	} else {
	  return params[key];
	}
  }
}