using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using PrettyGood.Util;

namespace PrettyGood.SpotifyTest
{
	class MusicData
	{
		class Artist
		{
			public string Name;
			public Dictionary<string, Track> Tracks = new Dictionary<string, Track>();
		}

		class Track
		{
			public string Name;
			public Dictionary<string, Album> Albums = new Dictionary<string, Album>();
		}

		class Album
		{
			public string Number;
			public string Name;
			public List<string> Paths = new List<string>();
		}

		Dictionary<string, Artist> artists = new Dictionary<string, Artist>();

		private static string ID(string s)
		{
			if (s == null) return "";
			return s.ToLower().Trim();
		}

		private static T Get<T>(Dictionary<string, T> d, string id, T df)
		{
			if (d.ContainsKey(id))
				return d[id];
			else
			{
				d.Add(id, df);
				return df;
			}
		}

		bool add(string artist, string album, string title, string tracknumber, string path)
		{
			if (string.IsNullOrEmpty(artist)) return false;
			if (string.IsNullOrEmpty(path)) return false;
			if (string.IsNullOrEmpty(title)) return false;

			Artist a = Get<Artist>(artists, ID( artist ), new Artist { Name = artist });
			Track t = Get<Track>(a.Tracks, ID(title), new Track { Name = title });

			foreach(var s in Util.CSharp.Enumerate("", album))
			{
				Album al = Get<Album>(t.Albums, ID(s), new Album { Name = s});
				if (al.Number == "" && tracknumber != "") al.Number = tracknumber;
				al.Paths.Add(path);
			}

			return true;
		}
		public int Count = 0;

		private static IEnumerable<string> Files(string root, string[] ex)
		{
			foreach (var x in ex)
			{
				foreach (var p in Directory.GetFiles(root, "*."+x, SearchOption.AllDirectories))
				{
					yield return p;
				}
			}
		}

		public List<string> getFiles(string root)
		{
			return new List<string>(Files(root, new string[] { "mp3", "flac", "ogg" }));
		}

		internal void add(string p)
		{
			var f = TagLib.File.Create(p);

			bool added = false;

			foreach (var x in Util.CSharp.Enumerate(TagLib.TagTypes.Id3v2, TagLib.TagTypes.Id3v1))
			{
				var t = f.GetTag(x);
				if (t == null) continue;
				bool ok = add(t.JoinedPerformers, t.Album, t.Title, t.Track.ToString(), p);
				if (ok) added = true;
			}

			if( added ) ++Count; 
		}

		internal string getPath(string artist, string album, string title, string tracknumber)
		{
			Artist a = Get<Artist>(artists, ID(artist), null);
			if (a == null) return "";
			Track t = Get<Track>(a.Tracks, ID(title), null);
			if (t == null) return "";
			Album al = Get<Album>(t.Albums, ID(album), null);
			if (al == null)
			{
				al = Get<Album>(t.Albums, "", null);
			}
			if (al == null) return "";
			return al.Paths[0];
		}
	}
}
