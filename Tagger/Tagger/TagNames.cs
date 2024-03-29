﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tagger
{
	class Id3Genre
	{
		public IEnumerable<KeyValuePair<int, string>> Generes
		{
			get
			{
				// http://www.multimediasoft.com/amp3dj/help/amp3dj_00003e.htm#ss13.3
				yield return new KeyValuePair<int, string>(0, "Blues");
				yield return new KeyValuePair<int, string>(1, "Classic Rock");
				yield return new KeyValuePair<int, string>(2, "Country");
				yield return new KeyValuePair<int, string>(3, "Dance");
				yield return new KeyValuePair<int, string>(4, "Disco");
				yield return new KeyValuePair<int, string>(5, "Funk");
				yield return new KeyValuePair<int, string>(6, "Grunge");
				yield return new KeyValuePair<int, string>(7, "Hip-Hop");
				yield return new KeyValuePair<int, string>(8, "Jazz");
				yield return new KeyValuePair<int, string>(9, "Metal");
				yield return new KeyValuePair<int, string>(10, "New Age");
				yield return new KeyValuePair<int, string>(11, "Oldies");
				yield return new KeyValuePair<int, string>(12, "Other");
				yield return new KeyValuePair<int, string>(13, "Pop");
				yield return new KeyValuePair<int, string>(14, "R&B");
				yield return new KeyValuePair<int, string>(15, "Rap");
				yield return new KeyValuePair<int, string>(16, "Reggae");
				yield return new KeyValuePair<int, string>(17, "Rock");
				yield return new KeyValuePair<int, string>(18, "Techno");
				yield return new KeyValuePair<int, string>(19, "Industrial");
				yield return new KeyValuePair<int, string>(20, "Alternative");
				yield return new KeyValuePair<int, string>(21, "Ska");
				yield return new KeyValuePair<int, string>(22, "Death Metal");
				yield return new KeyValuePair<int, string>(23, "Pranks");
				yield return new KeyValuePair<int, string>(24, "Soundtrack");
				yield return new KeyValuePair<int, string>(25, "Euro-Techno");
				yield return new KeyValuePair<int, string>(26, "Ambient");
				yield return new KeyValuePair<int, string>(27, "Trip-Hop");
				yield return new KeyValuePair<int, string>(28, "Vocal");
				yield return new KeyValuePair<int, string>(29, "Jazz+Funk");
				yield return new KeyValuePair<int, string>(30, "Fusion");
				yield return new KeyValuePair<int, string>(31, "Trance");
				yield return new KeyValuePair<int, string>(32, "Classical");
				yield return new KeyValuePair<int, string>(33, "Instrumental");
				yield return new KeyValuePair<int, string>(34, "Acid");
				yield return new KeyValuePair<int, string>(35, "House");
				yield return new KeyValuePair<int, string>(36, "Game");
				yield return new KeyValuePair<int, string>(37, "Sound Clip");
				yield return new KeyValuePair<int, string>(38, "Gospel");
				yield return new KeyValuePair<int, string>(39, "Noise");
				yield return new KeyValuePair<int, string>(40, "Alternative Rock");
				yield return new KeyValuePair<int, string>(41, "Bass");
				yield return new KeyValuePair<int, string>(42, "Soul");
				yield return new KeyValuePair<int, string>(43, "Punk");
				yield return new KeyValuePair<int, string>(44, "Space");
				yield return new KeyValuePair<int, string>(45, "Meditative");
				yield return new KeyValuePair<int, string>(46, "Instrumental Pop");
				yield return new KeyValuePair<int, string>(47, "Instrumental Rock");
				yield return new KeyValuePair<int, string>(48, "Ethnic");
				yield return new KeyValuePair<int, string>(49, "Gothic");
				yield return new KeyValuePair<int, string>(50, "Darkwave");
				yield return new KeyValuePair<int, string>(51, "Techno-Industrial");
				yield return new KeyValuePair<int, string>(52, "Electronic");
				yield return new KeyValuePair<int, string>(53, "Pop-Folk");
				yield return new KeyValuePair<int, string>(54, "Eurodance");
				yield return new KeyValuePair<int, string>(55, "Dream");
				yield return new KeyValuePair<int, string>(56, "Southern Rock");
				yield return new KeyValuePair<int, string>(57, "Comedy");
				yield return new KeyValuePair<int, string>(58, "Cult");
				yield return new KeyValuePair<int, string>(59, "Gangsta");
				yield return new KeyValuePair<int, string>(60, "Top 40");
				yield return new KeyValuePair<int, string>(61, "Christian Rap");
				yield return new KeyValuePair<int, string>(62, "Pop/Funk");
				yield return new KeyValuePair<int, string>(63, "Jungle");
				yield return new KeyValuePair<int, string>(64, "Native US");
				yield return new KeyValuePair<int, string>(65, "Cabaret");
				yield return new KeyValuePair<int, string>(66, "New Wave");
				yield return new KeyValuePair<int, string>(67, "Psychadelic");
				yield return new KeyValuePair<int, string>(68, "Rave");
				yield return new KeyValuePair<int, string>(69, "Showtunes");
				yield return new KeyValuePair<int, string>(70, "Trailer");
				yield return new KeyValuePair<int, string>(71, "Lo-Fi");
				yield return new KeyValuePair<int, string>(72, "Tribal");
				yield return new KeyValuePair<int, string>(73, "Acid Punk");
				yield return new KeyValuePair<int, string>(74, "Acid Jazz");
				yield return new KeyValuePair<int, string>(75, "Polka");
				yield return new KeyValuePair<int, string>(76, "Retro");
				yield return new KeyValuePair<int, string>(77, "Musical");
				yield return new KeyValuePair<int, string>(78, "Rock & Roll");
				yield return new KeyValuePair<int, string>(79, "Hard Rock");
				yield return new KeyValuePair<int, string>(80, "Folk");
				yield return new KeyValuePair<int, string>(81, "Folk-Rock");
				yield return new KeyValuePair<int, string>(82, "National Folk");
				yield return new KeyValuePair<int, string>(83, "Swing");
				yield return new KeyValuePair<int, string>(84, "Fast Fusion");
				yield return new KeyValuePair<int, string>(85, "Bebob");
				yield return new KeyValuePair<int, string>(86, "Latin");
				yield return new KeyValuePair<int, string>(87, "Revival");
				yield return new KeyValuePair<int, string>(88, "Celtic");
				yield return new KeyValuePair<int, string>(89, "Bluegrass");
				yield return new KeyValuePair<int, string>(90, "Avantgarde");
				yield return new KeyValuePair<int, string>(91, "Gothic Rock");
				yield return new KeyValuePair<int, string>(92, "Progressive Rock");
				yield return new KeyValuePair<int, string>(93, "Psychedelic Rock");
				yield return new KeyValuePair<int, string>(94, "Symphonic Rock");
				yield return new KeyValuePair<int, string>(95, "Slow Rock");
				yield return new KeyValuePair<int, string>(96, "Big Band");
				yield return new KeyValuePair<int, string>(97, "Chorus");
				yield return new KeyValuePair<int, string>(98, "Easy Listening");
				yield return new KeyValuePair<int, string>(99, "Acoustic");
				yield return new KeyValuePair<int, string>(100, "Humour");
				yield return new KeyValuePair<int, string>(101, "Speech");
				yield return new KeyValuePair<int, string>(102, "Chanson");
				yield return new KeyValuePair<int, string>(103, "Opera");
				yield return new KeyValuePair<int, string>(104, "Chamber Music");
				yield return new KeyValuePair<int, string>(105, "Sonata");
				yield return new KeyValuePair<int, string>(106, "Symphony");
				yield return new KeyValuePair<int, string>(107, "Booty Bass");
				yield return new KeyValuePair<int, string>(108, "Primus");
				yield return new KeyValuePair<int, string>(109, "Porn Groove");
				yield return new KeyValuePair<int, string>(110, "Satire");
				yield return new KeyValuePair<int, string>(111, "Slow Jam");
				yield return new KeyValuePair<int, string>(112, "Club");
				yield return new KeyValuePair<int, string>(113, "Tango");
				yield return new KeyValuePair<int, string>(114, "Samba");
				yield return new KeyValuePair<int, string>(115, "Folklore");
				yield return new KeyValuePair<int, string>(116, "Ballad");
				yield return new KeyValuePair<int, string>(117, "Power Ballad");
				yield return new KeyValuePair<int, string>(118, "Rhythmic Soul");
				yield return new KeyValuePair<int, string>(119, "Freestyle");
				yield return new KeyValuePair<int, string>(120, "Duet");
				yield return new KeyValuePair<int, string>(121, "Punk Rock");
				yield return new KeyValuePair<int, string>(122, "Drum Solo");
				yield return new KeyValuePair<int, string>(123, "Acapella");
				yield return new KeyValuePair<int, string>(124, "Euro-House");
				yield return new KeyValuePair<int, string>(125, "Dance Hall");
				yield return new KeyValuePair<int, string>(126, "Goa");
				yield return new KeyValuePair<int, string>(127, "Drum & Bass");
				yield return new KeyValuePair<int, string>(128, "Club - House");
				yield return new KeyValuePair<int, string>(129, "Hardcore");
				yield return new KeyValuePair<int, string>(130, "Terror");
				yield return new KeyValuePair<int, string>(131, "Indie");
				yield return new KeyValuePair<int, string>(132, "BritPop");
				yield return new KeyValuePair<int, string>(133, "Negerpunk");
				yield return new KeyValuePair<int, string>(134, "Polsk Punk");
				yield return new KeyValuePair<int, string>(135, "Beat");
				yield return new KeyValuePair<int, string>(136, "Christian Gangsta Rap");
				yield return new KeyValuePair<int, string>(137, "Heavy Metal");
				yield return new KeyValuePair<int, string>(138, "Black Metal");
				yield return new KeyValuePair<int, string>(139, "Crossover");
				yield return new KeyValuePair<int, string>(140, "Contemporary Christian");
				yield return new KeyValuePair<int, string>(141, "Christian Rock");
				yield return new KeyValuePair<int, string>(142, "Merengue");
				yield return new KeyValuePair<int, string>(143, "Salsa");
				yield return new KeyValuePair<int, string>(144, "Thrash Metal");
				yield return new KeyValuePair<int, string>(145, "Anime");
				yield return new KeyValuePair<int, string>(146, "JPop");
				yield return new KeyValuePair<int, string>(147, "Synthpop");
			}
		}
	}
}
