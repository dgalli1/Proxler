# Proxler
A tool which is pretty cool

Bookmark:

```javascript

javascript:var a=window.location.pathname.split("/")[2];
if(!isNaN(a)&&window.location.host=="proxer.me") {
location.href="proxler://" + window.location.pathname.split("/")[2];
} else {
	alert("Ungültige Webseite/Keine ID gefunden");
}

```