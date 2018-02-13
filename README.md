# Proxler
Ist ein downloader für die Webseite proxer.me.

# Features
<ul>
	<li>JDownloader support (Multi-Threaded download)</li>
	<li>youtube-dl support um das Download intern zu erledigen</li>
	<li>Online-Checker</li>
	<li>Hoster Priorität</li>
	<li>Browser Favorit der den Download direkt startet</li>
	<li>Limitierbare Download geschwindigkeit</li>
	<li>Warteschlangen funktion für das downloaden mehrer Animes</li>
	<li>Cloudflare Anti-Anti-DDOS Protection</li>
</ul>

Bookmark:

```javascript

javascript:var a=window.location.pathname.split("/")[2];
if(!isNaN(a)&&window.location.host=="proxer.me") {
location.href="proxler://" + window.location.pathname.split("/")[2];
} else {
	alert("Ungültige Webseite/Keine ID gefunden");
}

```
