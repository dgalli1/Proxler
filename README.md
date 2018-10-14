# Proxler
Ist ein downloader für die Webseite proxer.me.

## Installation
Lade dir das Programm von [download](https://github.com/daYMAN007/Proxler/releases/latest) herunter.
Enpacke den Ordner und führe die "proxler.exe" mit Adminrechten aus. Die folgenden male kann das Programm normal gestartet werden.

Als nächstes solltest du die Einstellungen überprüfen. Das setzten eines Ordners für die Downloads ist zurzeit zwingend!


### Warum braucht das Programm Adminrechte?
Beim ersten start werden Registery einträge erfasst die das Verwenden eines Url formates erlaubt
z.B ([proxler://85](proxler://85))

## Features
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

## Bookmark/Favorit:
Füge dieses JS snippet zu deiner Favoriten leiste hinzu um einen schnellen download eines Animes zu erlauben. Wenn du dich auf einer gültigen Seite befindest wird das download automatisch beginnen!

```javascript

javascript:var a=window.location.pathname.split("/")[2];
if(!isNaN(a)&&window.location.host=="proxer.me") {
location.href="proxler://" + window.location.pathname.split("/")[2];
} else {
	alert("Ungültige Webseite/Keine ID gefunden");
}

```
