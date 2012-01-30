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

		void add(string artist, string album, string title, string tracknumber, string path)
		{
			Artist a = Get<Artist>(artists, getArtistId(artist), new Artist { Name = artist });
			Track t = Get<Track>(a.Tracks, getTitleId(title), new Track { Name = title });

			foreach(var s in Util.CSharp.Enumerate("", clean(album)))
			{
				Album al = Get<Album>(t.Albums, getAlbumId(s), new Album { Name = s });
				if (al.Number == "" && tracknumber != "") al.Number = tracknumber;
				al.Paths.Add(path);
			}
		}

		private static string getAlbumId(string s)
		{
			return ID(s);
		}

		private string getTitleId(string title)
		{
			return clean(ID(title));
		}

		private string getArtistId(string artist)
		{
			return clean(ID(artist)).RemoveFromStartIfFound("the ").Trim();
		}

		private string clean(string p)
		{
			if (p == null) return p;
            string s = p;
            if (Words) s = s.RemoveAll("bonus track", "original version", "radio version", "album version explcit", "album version");
            if (SmartReplace) s = s.Replace("and", "&");
			if (Clean) s = s.RemoveAll("'", "`", "´", "!", "(", ")", "[", "]", "{", "}", "/", "\\", ",", "#", "-", ",", ".", " ", "?");
			return s;
		}

		public int Count
		{
			get;
			private set;
		}

		public bool Clean = true;
        public bool Words = true;
        public bool SmartReplace = true;

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

        bool SingleEntryPerFile = true;

		internal void add(string p, ref List<string> errors)
		{
            try
            {
				var data = ExtractInformation(p, ref errors);

				if (data != null)
				{
					add(data.Artist, data.Album, data.Title, data.Track, p);
					++Count;
				}
            }
            catch (TagLib.CorruptFileException cf)
            {
				errors.Add(string.Format("Corruption detected in {0}: {1}", p, cf.Message));
            }
		}

		public class Information
		{
			public string Artist;
			public string Album;
			public string Title;
			public string Track;
		}

		public static Information ExtractInformation(string p, ref List<string> errors)
		{
			var f = TagLib.File.Create(p);

			if (string.IsNullOrEmpty(p)) return null;

			foreach (var x in Util.CSharp.Enumerate(TagLib.TagTypes.Id3v2, TagLib.TagTypes.Id3v1))
			{
				TagLib.Tag t = null;
				try
				{
					t = f.GetTag(x);
				}
				catch (Exception ex)
				{
					errors.Add(string.Format("{0}: {1}", p, ex.Message));
					// missing tag...
				}
				if (t == null) continue;
				var info = new Information { Artist=t.JoinedPerformers, Album=t.Album, Title=t.Title, Track=t.Track.ToString() };

				if (string.IsNullOrEmpty(info.Artist)) continue;
				if (string.IsNullOrEmpty(info.Title)) continue;

				return info;
			}
			return null;
		}

		internal string getPath(string artist, string album, string title, string tracknumber)
		{
			Artist a = Get<Artist>(artists, getArtistOrOverride(getArtistId(artist)), null);
			if (a == null) return "";
			Track t = Get<Track>(a.Tracks, getTitleId(title), null);
			if (t == null) return "";
			Album al = Get<Album>(t.Albums, getAlbumId(album), null);
			if (al == null)
			{
				al = Get<Album>(t.Albums, "", null);
			}
			if (al == null) return "";
			return al.Paths[0];
		}

		private string getArtistOrOverride(string s)
		{
			if (artistOverrids.ContainsKey(s))
			{
				return artistOverrids[s];
			}
			else
			{
				return s;
			}
		}

		Dictionary<string, string> artistOverrids = new Dictionary<string, string>();

		internal void overideArtist(string from, string to)
		{
            var f = getArtistId(from);
            if( artistOverrids.ContainsKey(f) == false )
			    artistOverrids.Add(f, getArtistId(to));
		}
	}
}
