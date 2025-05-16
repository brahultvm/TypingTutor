using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Reflection;

namespace Keyboard
{

    public class LogWriter
    {
        private string m_exePath = string.Empty;
        public LogWriter(string logMessage)
        {
            LogWrite(logMessage);
        }
        public void LogWrite(string logMessage)
        {
            //m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //try
            //{
            //    using (StreamWriter w = File.AppendText(m_exePath + "\\" + "log.txt"))
            //    {
            //        Log(logMessage, w);
            //    }
            //}
            //catch (Exception ex)
            //{
            //}
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                //txtWriter.Write("\r\nLog Entry : ");
                //txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                //    DateTime.Now.ToLongDateString());
                //txtWriter.WriteLine("  :");
                //txtWriter.WriteLine("  :{0}", logMessage);
                //txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }
    }
    public class Common
	{
		public static bool sound = true;

		public List<string> lstData = new List<string>();

		public static Color GetColorForKey(char key)
		{
			Color result = Color.Black;
			switch (key)
			{
			case '1':
			case '!':
			case 'a':
			case 'A':
			case 'q':
			case 'Q':
			case 'z':
			case 'Z':
				result = Color.Red;
				break;
			case '2':
			case '@':
			case 's':
			case 'S':
			case 'w':
			case 'W':
			case 'x':
			case 'X':
				result = Color.Orange;
				break;
			case '3':
			case '#':
			case 'c':
			case 'C':
			case 'd':
			case 'D':
			case 'e':
			case 'E':
				result = Color.GreenYellow;
				break;
			case '4':
			case '$':
			case '5':
			case '%':
			case 'b':			
			case 'B':			
			case 'f':
			case 'F':
			case 'g':
			case 'G':
			case 'r':
			case 'R':
			case 't':
			case 'T':
			case 'v':
			case 'V':
				result = Color.SkyBlue;
				break;
			case '6':
			case '^':
			case '7':
			case '&':
			case 'h':
			case 'H':
			case 'j':
			case 'J':
			case 'm':
			case 'M':
			case 'n':
			case 'N':
			case 'u':
			case 'U':
			case 'y':
			case 'Y':
				result = Color.LightSteelBlue;
				break;
			case ' ':
			case '8':
			case '*':
			case '<':			
			case 'i':
			case 'I':
			case 'k':
			case 'K':
				result = Color.SkyBlue;
				break;
			case '.':
			case '9':
			case '>':
			case 'l':
			case 'o':
				result = Color.LightYellow;
				break;
			case '-':
			case '/':
			case '0':
			case ';':
			case '=':
			case '[':
			case '\\':
			case ']':
			case 'p':
				result = Color.LightGreen;
				break;
			}
			return result;
		}

		public static void Play()
		{
			if (sound)
			{
				using SoundPlayer soundPlayer = new SoundPlayer(Resource1.type);
				soundPlayer.Play();
				soundPlayer.Dispose();
			}
		}

		public static void Error()
		{
			if (sound)
			{
				using SoundPlayer soundPlayer = new SoundPlayer(Resource1.err);
				soundPlayer.Play();
				soundPlayer.Dispose();
			}
		}

		public static void Completed()
		{
			if (sound)
			{
				using SoundPlayer soundPlayer = new SoundPlayer(Resource1.complete);
				soundPlayer.Play();
				soundPlayer.Dispose();
			}
		}
        public void LoadTamilBasicRow()
        {
            lstData.Clear();
            if (lstData.Count <= 0)
            {
                lstData.Add("Asdf ;lkj asdf ;lkj asdf ;lkj asdf ;lkj asdf ;lkj asdf ;lkj");
                lstData.Add("asdf ;lkj asdf ;lkj asdf ;lkj asdf ;lkj asdf ;lkj asdf ;lkj");
                lstData.Add("asdf ;lkj asdf ;lkj asdf ;lkj asdf ;lkj asdf ;lkj asdf ;lkj");
                lstData.Add("asdfgf ;lkjhj asdfgf ;lkjhj asdfgf ;lkjhj asdfgf ;lkjhj asdfgf ;lkjhj");
                lstData.Add("asdfgf ;lkjhj asdfgf ;lkjhj asdfgf ;lkjhj asdfgf ;lkjhj asdfgf ;lkjhj");
                lstData.Add("asdfgf ;lkjhj asdfgf ;lkjhj asdfgf ;lkjhj asdfgf ;lkjhj asdfgf ;lkjhj");
                lstData.Add("asdfgf ;lkjhj asdfgf ;lkjhj asdfgf ;lkjhj asdfgf ;lkjhj asdfgf ;lkjhj");
                lstData.Add("fsk; fsk; fsk; fsk; fsk; fsk; fsk; fsk; fsk; fsk; fsk; fsk; fsk;");
                lstData.Add("fsk; fsk; fsk; fsk; fsk; fsk; fsk; fsk; fsk; fsk; fsk; fsk; fsk;");
                lstData.Add("fsk; fsk; fsk; fsk; fsk; fsk; fsk; fsk; fsk; fsk; fsk; fsk; fsk;");
                lstData.Add("fzk; fzk; fzk; fzk; fzk;");
                lstData.Add("kdk; kdk; kdk; kdk; kdk;");
                lstData.Add("fld; fld; fld; fld; fld;");
                lstData.Add("klk; klk; klk; klk; klk;");
                lstData.Add("fjh; fjh; fjh; fjh; fjh;");
                lstData.Add("fha; fha; fha; fha; fha;");
                lstData.Add("fgk; fgk; fgk; fgk; fgk;");
                lstData.Add("kfs; kfs; kfs; kfs; kfs;");
                lstData.Add("gad; gad; gad; gad; gad;");
                lstData.Add("jhdk; jhdk; jhdk; jhdk; jhdk;");
                lstData.Add("fhdk; fhdk; fhdk; fhdk; fhdk;");
                lstData.Add("khak; khak; khak; khak; khak;");
                lstData.Add("ghlk; ghlk; ghlk; ghlk; ghlk;");
                lstData.Add("khlk; khlk; khlk; khlk; khlk;");
                lstData.Add("flfk; flfk; flfk; flfk; flfk;");
                lstData.Add("fkfk; fkfk; fkfk; fkfk; fkfk;");
                lstData.Add("ahkk; ahkk; ahkk; ahkk; ahkk;");
                lstData.Add("fs;sd; fs;sd; fs;sd; fs;sd; fs;sd;");
                lstData.Add("jhak; jhak; jhak; jhak; jhak;");
                lstData.Add("fg;gk; fg;gk; fg;gk; fg;gk; fg;gk;");
                lstData.Add("gl;lk; gl;lk; gl;lk; gl;lk; gl;lk;");
                lstData.Add("jj;jk; jj;jk; jj;jk; jj;jk; jj;jk;");
                lstData.Add("gs;sk; gs;sk; gs;sk; gs;sk; gs;sk;");
                lstData.Add("kf;fs; kf;fs; kf;fs; kf;fs; kf;fs;");
                lstData.Add("fl;lk; fl;lk; fl;lk; fl;lk; fl;lk;");
                lstData.Add("fk;gk; fk;gk; fk;gk; fk;gk; fk;gk;");
                lstData.Add("khjk; khjk; khjk; khjk; khjk;");
                lstData.Add("jhfk; jhfk; jhfk; jhfk; jhfk;");
                lstData.Add("lgha; lgha; lgha; lgha; lgha;");
                lstData.Add("flkhd; flkhd; flkhd; flkhd; flkhd;");
                lstData.Add("jhafk; jhafk; jhafk; jhafk; jhafk;");
                lstData.Add("fhdfk; fhdfk; fhdfk; fhdfk; fhdfk;");
                lstData.Add("ghl;ld; ghl;ld; ghl;ld; ghl;ld; ghl;ld;");
                lstData.Add("khsak; khsak; khsak; khsak; khsak;");
                lstData.Add("gk;gha; gk;gha; gk;gha; gk;gha; gk;gha;");
                lstData.Add("fl;llk; fl;llk; fl;llk; fl;llk; fl;llk;");
                lstData.Add("fh;j;jh fh;j;jh fh;j;jh fh;j;jh fh;j;jh");
                lstData.Add("lhf;lh; lhf;lh; lhf;lh; lhf;lh; lhf;lh;");
                lstData.Add("asdfgf 'l;kjhj asdfgf 'l;kjhj asdfgf 'l;kjhj asdfgf 'l;kjhj");
                lstData.Add("asdfgf 'l;kjhj asdfgf 'l;kjhj asdfgf 'l;kjhj asdfgf 'l;kjhj");
                lstData.Add("asdfgf 'l;kjhj asdfgf 'l;kjhj asdfgf 'l;kjhj asdfgf 'l;kjhj");
                lstData.Add("asdfgf 'l;kjhj asdfgf 'l;kjhj asdfgf 'l;kjhj asdfgf 'l;kjhj");
                lstData.Add("fGF fGF fGF fGF fGF");
                lstData.Add("FGK FGK FGK FGK FGK");
                lstData.Add("f';F f';F f';F f';F f';F");
                lstData.Add("Kl;L Kl;L Kl;L Kl;L Kl;L");
                lstData.Add("fLF fLF fLF fLF fLF");
                lstData.Add("Jfs; Jfs; Jfs; Jfs; Jfs;");
                lstData.Add("kjF kjF kjF kjF kjF");
                lstData.Add("gHJ gHJ gHJ gHJ gHJ");
                lstData.Add("KHk; KHk; KHk; KHk; KHk;");
                lstData.Add("FKjk; FKjk; FKjk; FKjk; FKjk;");
                lstData.Add("FHha; FHha; FHha; FHha; FHha;");
                lstData.Add("fGj;J fGj;J fGj;J fGj;J fGj;J");
                lstData.Add("\"hdk; \"hdk;\"hdk; \"hdk;\"hdk; ");
				lstData.Add("fHfk; fHfk; fHfk; fHfk; fHfk;");
                lstData.Add("Fkl;L Fkl;L Fkl;L Fkl;L Fkl;L");
                lstData.Add("lg;gh lg;gh lg;gh lg;gh lg;gh");
                lstData.Add("Js;Sk; Js;Sk; Js;Sk; Js;Sk; Js;Sk;");
                lstData.Add("jiyyhkh jiyefuk; te;jhh;");
                lstData.Add("thiHg;gHk; kw;Wk; khk;gHk; th';F");
                lstData.Add("FLitia ed;wha;f; FYf;F");
                lstData.Add("rl;lrig Kd;dth; rghehafiug; ghh;j;Jf; TWf");

            }
        }
        public void LoadBasicRow()
		{
			lstData.Clear();

            if (lstData.Count <= 0)
			{
				lstData.Add("asdf ;lkj asdf ;lkj asdf ;lkj asdf ;lkj");
				lstData.Add("asdf ;lkj asdf ;lkj asdf ;lkj asdf ;lkj");
				lstData.Add("asdf ;lkj asdf ;lkj asdf ;lkj asdf ;lkj");
				lstData.Add("asdfgf ;lkjhj asdfgf ;lkjhj asdfgf ;lkjhj");
				lstData.Add("asdfgf ;lkjhj asdfgf ;lkjhj asdfgf ;lkjhj");
				lstData.Add("asdfgf ;lkjhj asdfgf ;lkjhj asdfgf ;lkjhj");
				lstData.Add("ask ask ask ask ask ask ask ask ask ask");
				lstData.Add("saf saf saf saf saf saf saf saf saf saf");
				lstData.Add("fag fag fag fag fag fag fag fag fag fag");
				lstData.Add("had had had had had had had had had had");
				lstData.Add("lads lads lads lads lads lads lads lads");
				lstData.Add("ahad ahad ahad ahad ahad ahad ahad ahad");
				lstData.Add("algal algal algal algal algal algal algal");
				lstData.Add("all all all all all all all all all all");
				lstData.Add("sal sal sal sal sal sal sal sal sal sal");
				lstData.Add("fad fad fad fad fad fad fad fad fad fad");
				lstData.Add("has has has has has has has has has has");
				lstData.Add("lags lags lags lags lags lags lags lags");
				lstData.Add("shah shah shah shah shah shah shah shah");
				lstData.Add("shall shall shall shall shall shall shall");
				lstData.Add("ash ash ash ash ash ash ash ash ash ash");
				lstData.Add("sad sad sad sad sad sad sad sad sad sad");
				lstData.Add("gas gas gas gas gas gas gas gas gas gas");
				lstData.Add("hag hag hag hag hag hag hag hag hag hag");
				lstData.Add("lass lass lass lass lass lass lass lass");
				lstData.Add("daff daff daff daff daff daff daff daff");
				lstData.Add("dhall dhall dhall dhall dhall dhall dhall");
				lstData.Add("aga aga aga aga aga aga aga aga aga aga");
				lstData.Add("dad dad dad dad dad dad dad dad dad dad");
				lstData.Add("gad gad gad gad gad gad gad gad gad gad");
				lstData.Add("hah hah hah hah hah hah hah hah hah hah");
				lstData.Add("alas alas alas alas alas alas alas alas");
				lstData.Add("dash dash dash dash dash dash dash dash");
				lstData.Add("flash flash flash flash flash flash flash");
				lstData.Add("add add add add add add add add add add");
				lstData.Add("dak dak dak dak dak dak dak dak dak dak");
				lstData.Add("gag gag gag gag gag gag gag gag gag gag");
				lstData.Add("haf haf haf haf haf haf haf haf haf haf");
				lstData.Add("adds adds adds adds adds adds adds adds");
				lstData.Add("glad glad glad glad glad glad glad glad");
				lstData.Add("lakhs lakhs lakhs lakhs lakhs lakhs lakhs");
				lstData.Add("awerqfa ;oiupj; awerqfa ;oiupj; awerqfa ;oiupj;");
				lstData.Add("awerqfa ;oiupj; awerqfa ;oiupj; awerqfa ;oiupj;");
				lstData.Add("awerqfa ;oiupj; awerqfa ;oiupj; awerqfa ;oiupj;");
				lstData.Add("awerqfa ;oiupj; awerqfa ;oiupj; awerqfa ;oiupj;");
				lstData.Add("awerqfa ;oiupj; awerqfa ;oiupj; awerqfa ;oiupj;");
				lstData.Add("awerqfa ;oiupj; awerqfa ;oiupj; awerqfa ;oiupj;");
				lstData.Add("we we we we we we we we we we ");
				lstData.Add("war war war war war war war war war war ");
				lstData.Add("quip quip quip quip quip quip quip quip quip quip ");
				lstData.Add("quaker quaker quaker quaker quaker quaker quaker quaker quaker quaker ");
				lstData.Add("quarrel quarrel quarrel quarrel quarrel quarrel quarrel quarrel quarrel quarrel ");
				lstData.Add("awkward awkward awkward awkward awkward awkward awkward awkward awkward awkward ");
				lstData.Add("quire quire quire quire quire quire quire quire quire quire ");
				lstData.Add("is is is is is is is is is is ");
				lstData.Add("wap wap wap wap wap wap wap wap wap wap ");
				lstData.Add("wale wale wale wale wale wale wale wale wale wale ");
				lstData.Add("world world world world world world world world world world ");
				lstData.Add("wakeful wakeful wakeful wakeful wakeful wakeful wakeful wakeful wakeful wakeful ");
				lstData.Add("squalor squalor squalor squalor squalor squalor squalor squalor squalor squalor ");
				lstData.Add("woeful woeful woeful woeful woeful woeful woeful woeful woeful woeful ");
				lstData.Add("us us us us us us us us us us ");
				lstData.Add("eke eke eke eke eke eke eke eke eke eke ");
				lstData.Add("pour pour pour pour pour pour pour pour pour pour ");
				lstData.Add("joker joker joker joker joker joker joker joker joker joker ");
				lstData.Add("poured poured poured poured poured poured poured poured poured poured ");
				lstData.Add("prepare prepare prepare prepare prepare prepare prepare prepare prepare prepare ");
				lstData.Add("dawdler dawdler dawdler dawdler dawdler dawdler dawdler dawdler dawdler dawdler ");
				lstData.Add("of of of of of of of of of of ");
				lstData.Add("elf elf elf elf elf elf elf elf elf elf ");
				lstData.Add("rule rule rule rule rule rule rule rule rule rule ");
				lstData.Add("riper riper riper riper riper riper riper riper riper riper ");
				lstData.Add("rosier rosier rosier rosier rosier rosier rosier rosier rosier rosier ");
				lstData.Add("ordered ordered ordered ordered ordered ordered ordered ordered ordered ordered ");
				lstData.Add("foolish foolish foolish foolish foolish foolish foolish foolish foolish foolish ");
				lstData.Add("if if if if if if if if if if ");
				lstData.Add("row row row row row row row row row row ");
				lstData.Add("idol idol idol idol idol idol idol idol idol idol ");
				lstData.Add("odour odour odour odour odour odour odour odour odour odour ");
				lstData.Add("opaque opaque opaque opaque opaque opaque opaque opaque opaque opaque ");
				lstData.Add("jealous jealous jealous jealous jealous jealous jealous jealous jealous jealous ");
				lstData.Add("kjaddar kjaddar kjaddar kjaddar kjaddar kjaddar kjaddar kjaddar kjaddar kjaddar ");
				lstData.Add("he he he he he he he he he he ");
				lstData.Add("rue rue rue rue rue rue rue rue rue rue ");
				lstData.Add("oaks oaks oaks oaks oaks oaks oaks oaks oaks oaks ");
				lstData.Add("ideal ideal ideal ideal ideal ideal ideal ideal ideal ideal ");
				lstData.Add("jigsaw jigsaw jigsaw jigsaw jigsaw jigsaw jigsaw jigsaw jigsaw jigsaw ");
				lstData.Add("failure failure failure failure failure failure failure failure failure failure ");
				lstData.Add("leagued leagued leagued leagued leagued leagued leagued leagued leagued leagued ");
				lstData.Add("do do do do do do do do do do ");
				lstData.Add("qua qua qua qua qua qua qua qua qua qua ");
				lstData.Add("used used used used used used used used used used ");
				lstData.Add("upper upper upper upper upper upper upper upper upper upper ");
				lstData.Add("upward upward upward upward upward upward upward ");
				lstData.Add("showers showers showers showers showers showers showers ");
				lstData.Add("wishful wishful wishful wishful wishful wishful wishful ");
				lstData.Add("gftfrf hjyjuj gftfrf hjyjuj gftfrf hjyjuj");
				lstData.Add("gftfrf hjyjuj gftfrf hjyjuj gftfrf hjyjuj");
				lstData.Add("gftfrf hjyjuj gftfrf hjyjuj gftfrf hjyjuj");
				lstData.Add("gftfrf hjyjuj gftfrf hjyjuj gftfrf hjyjuj");
				lstData.Add("gftfrf hjyjuj gftfrf hjyjuj gftfrf hjyjuj");
				lstData.Add("azxcvf lkmnbj azxcvf lkmnbj azxcvf lkmnbj ");
				lstData.Add("azxcvf lkmnbj azxcvf lkmnbj azxcvf lkmnbj ");
				lstData.Add("azxcvf lkmnbj azxcvf lkmnbj azxcvf lkmnbj ");
				lstData.Add("azxcvf lkmnbj azxcvf lkmnbj azxcvf lkmnbj ");
				lstData.Add("azxcvf lkmnbj azxcvf lkmnbj azxcvf lkmnbj ");
				lstData.Add("zlonal zlonal zlonal zlonal zlonal zlonal zlonal zlonal zlonal zlonal ");
				lstData.Add("colinm colinm colinm colinm colinm colinm colinm colinm colinm colinm ");
				lstData.Add("maximum maximum maximum maximum maximum maximum maximum maximum maximum maximum ");
				lstData.Add("cylinder cylinder cylinder cylinder cylinder cylinder cylinder cylinder cylinder cylinder ");
				lstData.Add("accompany accompany accompany accompany accompany accompany");
				lstData.Add("xebec xebec xebec xebec xebec xebec xebec xebec xebec xebec ");
				lstData.Add("naming naming naming naming naming naming naming naming naming naming ");
				lstData.Add("minimum minimum minimum minimum minimum minimum ");
				lstData.Add("medicine medicine medicine medicine medicine  ");
				lstData.Add("exemption exemption exemption exemption exemption exemption");
				lstData.Add("xylem xylem xylem xylem xylem xylem xylem xylem xylem xylem ");
				lstData.Add("taxing taxing taxing taxing taxing taxing taxing taxing taxing taxing ");
				lstData.Add("swizzle swizzle swizzle swizzle swizzle swizzle swizzle swizzle swizzle swizzle ");
				lstData.Add("commenly commenly commenly commenly commenly ");
				lstData.Add("primitive primitive primitive primitive primitive primitive");
				lstData.Add("cobra cobra cobra cobra cobra cobra cobra cobra cobra cobra ");
				lstData.Add("wizard wizard wizard wizard wizard wizard wizard wizard wizard wizard ");
				lstData.Add("symbols symbols symbols symbols symbols symbols symbols symbols symbols symbols ");
				lstData.Add("election election election election election election election election election election ");
				lstData.Add("available available available available available available available available available available ");
				lstData.Add("crime crime crime crime crime crime crime crime crime crime ");
				lstData.Add("behalf behalf behalf behalf behalf behalf behalf behalf behalf behalf ");
				lstData.Add("syringe syringe syringe syringe syringe syringe syringe syringe syringe syringe ");
				lstData.Add("mnemonic mnemonic mnemonic mnemonic mnemonic mnemonic mnemonic mnemonic mnemonic mnemonic ");
				lstData.Add("amendment amendment amendment amendment amendment amendment amendment amendment amendment amendment ");
				lstData.Add("voice voice voice voice voice voice voice voice voice voice ");
				lstData.Add("cheque cheque cheque cheque cheque cheque cheque cheque cheque cheque ");
				lstData.Add("thunder thunder thunder thunder thunder thunder thunder thunder thunder thunder ");
				lstData.Add("phonetic phonetic phonetic phonetic phonetic phonetic phonetic phonetic phonetic phonetic ");
				lstData.Add("movements movements movements movements movements movements movements movements movements movements ");
				lstData.Add("vizov vizov vizov vizov vizov vizov vizov vizov vizov vizov ");
				lstData.Add("volume volume volume volume volume volume volume volume volume volume ");
				lstData.Add("cobbler cobbler cobbler cobbler cobbler cobbler cobbler cobbler cobbler cobbler ");
				lstData.Add("monopoly monopoly monopoly monopoly monopoly monopoly monopoly monopoly monopoly monopoly ");
				lstData.Add("questions questions questions questions questions questions questions questions questions questions ");
				lstData.Add("bumpy bumpy bumpy bumpy bumpy bumpy bumpy bumpy bumpy bumpy ");
				lstData.Add("number number number number number number number number number number ");
				lstData.Add("machine machine machine machine machine machine machine machine machine machine ");
				lstData.Add("judgment judgment judgment judgment judgment judgment judgment judgment judgment judgment ");
				lstData.Add("gymnastic gymnastic gymnastic gymnastic gymnastic gymnastic gymnastic gymnastic gymnastic gymnastic ");
				lstData.Add("bunch bunch bunch bunch bunch bunch bunch bunch bunch bunch ");
				lstData.Add("public public public public public public public public public public ");
				lstData.Add("reneoed reneoed reneoed reneoed reneoed reneoed reneoed reneoed reneoed reneoed ");
				lstData.Add("relaxing relaxing relaxing relaxing relaxing relaxing relaxing relaxing relaxing relaxing ");
				lstData.Add("nightgown nightgown nightgown nightgown nightgown nightgown nightgown nightgown nightgown nightgown ");
				lstData.Add("abcdefghijklmnopqrstuvwxyz., zyxwvutsrqponmlkjihgfedcba.,");
				lstData.Add("abcdefghijklmnopqrstuvwxyz., zyxwvutsrqponmlkjihgfedcba.,");
				lstData.Add("abcdefghijklmnopqrstuvwxyz., zyxwvutsrqponmlkjihgfedcba.,");
				lstData.Add("abcdefghijklmnopqrstuvwxyz., zyxwvutsrqponmlkjihgfedcba.,");
				lstData.Add("abcdefghijklmnopqrstuvwxyz., zyxwvutsrqponmlkjihgfedcba.,");
				lstData.Add("abcdefghijklmnopqrstuvwxyz., zyxwvutsrqponmlkjihgfedcba.,");
				lstData.Add("123454 098767 123454 098767 123454 098767 123454 098767");
				lstData.Add("123454 098767 123454 098767 123454 098767 123454 098767");
				lstData.Add("123454 098767 123454 098767 123454 098767 123454 098767");
				lstData.Add("123454 098767 123454 098767 123454 098767 123454 098767");
				lstData.Add("pack my box with five dozen liquor jugs");
				lstData.Add("pack my box with five dozen liquor jugs");
				lstData.Add("pack my box with five dozen liquor jugs");
				lstData.Add("pack my box with five dozen liquor jugs");
				lstData.Add("pack my box with five dozen liquor jugs");
				lstData.Add("pack my box with five dozen liquor jugs");
				lstData.Add("The quick brown fox jumps over the lazy dog");
				lstData.Add("The quick brown fox jumps over the lazy dog");
				lstData.Add("The quick brown fox jumps over the lazy dog");
				lstData.Add("The quick brown fox jumps over the lazy dog");
				lstData.Add("Will you please help me to complete the work?");
				lstData.Add("Will you please help me to complete the work?");
				lstData.Add("Will you please help me to complete the work?");
				lstData.Add("Will you please help me to complete the work?");
				lstData.Add("Will you please help me to complete the work?");
				lstData.Add("Will you please help me to complete the work?");
			}
		}
	}
}
