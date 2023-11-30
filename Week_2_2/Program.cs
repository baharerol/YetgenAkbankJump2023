using Week_2_2.Entities;
using Week_2_2.Services;

Console.WriteLine("Sqotify - Music for Noone");

string cuurentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.Parent?.FullName;

Console.WriteLine();

var song1 = new Song("Requiem k. 626", "W. A. Mozart", "Orchestre national de France", null);
var song2 = new Song("Sonata No.6 in F Major", "L. Beethoven", "Fazıl Say", "Warner Music");
var song3 = new Song("Moonlight Sonata", "Ludwig van Beethoven", "Various Artists", "Classical Records");
var song4 = new Song("The Four Seasons", "Antonio Vivaldi", "Chamber Orchestra", "Baroque Productions");



var playlist1 = new Playlist(song1);
playlist1.AddSong(song2);
playlist1.AddSong(song3);
playlist1.AddSong(song4);

Console.WriteLine("Before Shuffle:");
Console.WriteLine(playlist1.GetSongs());

playlist1.ShuffleSongs();

Console.WriteLine("\n\nAfter Shuffle:");
Console.WriteLine(playlist1.GetSongs());

NotepadServcie notepadService = new();
notepadService.PlaylistToNotepad(playlist1);

