using SW = SeanWelton;

public static class NameGenerator
{

    #region Names Arrays
    private static readonly string[] familyNames = new string[]
    {
        "Abe", "Adachi", "Akamatsu", "Akiyama", "Ando", "Anzai", "Araki", "Asakura", "Ashikaga", "Asano",
        "Baba", "Ban", "Bessho", "Chiba", "Chosokabe", "Date", "Doi", "Echizen", "Enomoto", "Esashi",
        "Fujimoto", "Fujita", "Fujiwara", "Fukuda", "Furukawa", "Furuya", "Gamo", "Goto", "Habuki", "Hachisuka",
        "Hamada", "Hamamura", "Hara", "Harada", "Hattori", "Hayakawa", "Hayashi", "Higuchi", "Hirano", "Hirata",
        "Hojo", "Honda", "Honma", "Hosokawa", "Ichikawa", "Ikeda", "Imagawa", "Inaba", "Inoue", "Ishida",
        "Ishii", "Ishikawa", "Ito", "Iwai", "Iwasaki", "Izawa", "Kajiwara", "Kakizaki", "Kamata", "Kaminaga",
        "Kaneko", "Kanemoto", "Kanou", "Kashiwagi", "Kataoka", "Katayama", "Kato", "Kawakami", "Kawamura", "Kazama",
        "Kikuchi", "Kimura", "Kinoshita", "Kirino", "Kitagawa", "Kobayakawa", "Kobayashi", "Kodama", "Koizumi", "Kojima",
        "Komatsu", "Konishi", "Koyama", "Kubo", "Kudou", "Kumagai", "Kuroda", "Kurosawa", "Kurushima", "Maeda",
        "Magara", "Makino", "Manabe", "Maruyama", "Masaki", "Masuda", "Masui", "Matsudaira", "Matsui", "Matsumoto",
        "Matsuura", "Mibuchi", "Minamoto", "Mineshige", "Miyagawa", "Miyake", "Miyamoto", "Mizoguchi", "Mizuno", "Morimoto",
        "Morita", "Mori", "Motegi", "Murakami", "Murata", "Nagakura", "Nagao", "Nagai", "Nagakura", "Nakahara",
        "Nakahashi", "Nakajima", "Nakamura", "Nakanishi", "Nakao", "Nakayama", "Nambu", "Nara", "Naruse", "Niimi",
        "Niwa", "Noguchi", "Noma", "Nomura", "Obata", "Obuchi", "Ogawa", "Oguri", "Ohara", "Ohno",
        "Okabe", "Okamoto", "Okazaki", "Oki", "Okubo", "Okuda", "Omori", "Onishi", "Onodera", "Onuma",
        "Oota", "Ootomo", "Ooya", "Ozawa", "Saeki", "Saito", "Sakagami", "Sakakibara", "Sakurai", "Sano",
        "Sasaki", "Satake", "Sato", "Sawai", "Sekiguchi", "Serizawa", "Shiba", "Shibata", "Shimada", "Shimizu",
        "Shinohara", "Shinoda", "Shiozaki", "Shirai", "Shiraishi", "Shirogane", "Shishido", "Soeda", "Sogabe", "Suematsu",
        "Sugai", "Sugawara", "Sugimoto", "Sugita", "Sugiyama", "Suzuki", "Tachibana", "Tadokoro", "Taguchi", "Taiga",
        "Takahashi", "Takakura", "Takamori", "Takanashi", "Takanobu", "Takano", "Takasugi", "Takayama", "Takechi", "Takenaka",
        "Takeshita", "Tamura", "Tanabe", "Tanaka", "Tani", "Tanimoto", "Tateishi", "Tatsuno", "Tojo", "Tokugawa",
        "Tomita", "Tone", "Torii", "Tosa", "Toyoda", "Tsuda", "Tsuchida", "Tsuchiya", "Tsukamoto", "Tsuruoka",
        "Uchida", "Ueda", "Uehara", "Ueno", "Uesugi", "Umezawa", "Uno", "Usui", "Wada", "Wakashima",
        "Wakatsuki", "Watanabe", "Yamada", "Yamagata", "Yamaguchi", "Yamaji", "Yamakawa", "Yamamoto", "Yamanaka", "Yamashita"
    };

    private static readonly string[] maleNames = new string[]
    {
        "Akihiro", "Akio", "Atsushi", "Chikashi", "Chikara", "Daichi", "Daigo", "Daisuke", "Eiji", "Eiichi",
        "Fumihiro", "Fumio", "Genji", "Gentarou", "Goro", "Hajime", "Haru", "Haruki", "Haruto", "Hayato",
        "Hideaki", "Hideki", "Hideo", "Hiroaki", "Hirofumi", "Hirohito", "Hiroki", "Hiromasa", "Hiromu", "Hironobu",
        "Hironori", "Hiroshi", "Hirotaka", "Hiroto", "Hisashi", "Ichiro", "Isamu", "Itsuki", "Iwao", "Junichi",
        "Junnosuke", "Juro", "Kaito", "Kazuaki", "Kazuhiko", "Kazuhiro", "Kazuki", "Kazuma", "Kazunari", "Kazuo",
        "Kei", "Keiji", "Keisuke", "Kenshin", "Kenta", "Kenzaburo", "Kichiro", "Kiyohiro", "Kiyoshi", "Kohei",
        "Koki", "Kota", "Kunihiko", "Kunitake", "Kuro", "Makoto", "Manabu", "Masaki", "Masanobu", "Masaru",
        "Masashi", "Masato", "Masayoshi", "Masayuki", "Michio", "Minoru", "Mitsuo", "Mitsuru", "Motoaki", "Naoki",
        "Naoya", "Noboru", "Nobuaki", "Nobuhiko", "Nobuo", "Norifumi", "Norihiro", "Osamu", "Renjiro", "Reo",
        "Rikuto", "Riku", "Rintaro", "Ryo", "Ryohei", "Ryoma", "Ryota", "Ryuuji", "Saburo", "Sadao",
        "Satoshi", "Satoru", "Seiji", "Seikichi", "Shigeru", "Shinichi", "Shinji", "Shinnosuke", "Shinya", "Sho",
        "Shohei", "Shoma", "Shun", "Shunsuke", "Soichi", "Souta", "Susumu", "Tadashi", "Taichi", "Taiga",
        "Taiki", "Takahiro", "Takashi", "Takayuki", "Takeo", "Takeshi", "Taku", "Takuma", "Takuya", "Tamotsu",
        "Taro", "Tatsuo", "Tetsuya", "Tetsuo", "Tomio", "Tomoaki", "Tomohiro", "Tomoki", "Toshihiro", "Toshio",
        "Toshiyuki", "Tsutomu", "Tsuyoshi", "Ukyou", "Wataru", "Yasuo", "Yasushi", "Yoji", "Yoshihiko", "Yoshikazu",
        "Yoshinari", "Yoshinobu", "Yoshio", "Yoshitaka", "Yoshiyuki", "Yuki", "Yukio", "Yuma", "Yuji", "Yukihiro",
        "Yuu", "Yuuki", "Yuusuke", "Zentaro", "Arata", "Chikara", "Hibiki", "Masaki", "Ranmaru", "Hikaru",
        "Raizo", "Fuyuki", "Masakazu", "Isao", "Nobuyuki", "Tsunetomo", "Masamune", "Takanobu", "Kagemitsu", "Takemoto",
        "Tokihiro", "Soutarou", "Shigekazu", "Kazunobu", "Tadayoshi", "Iemitsu", "Motonari", "Masazane", "Sakon", "Yoritomo"
    };

    private static readonly string[] femaleNames = new string[]
    {
        "Aiko", "Akemi", "Ami", "Asami", "Ayaka", "Ayako", "Ayame", "Chie", "Chika", "Chiyo",
        "Emi", "Eriko", "Etsuko", "Fumiko", "Fuyuko", "Hana", "Hanako", "Haruka", "Harumi", "Hatsue",
        "Hibiki", "Hideko", "Hikaru", "Himeko", "Hinako", "Hiroko", "Hisako", "Hitomi", "Honami", "Hotaru",
        "Izumi", "Junko", "Kaede", "Kaho", "Kanna", "Kanako", "Karin", "Kasumi", "Kazue", "Keiko",
        "Kikue", "Kikuko", "Kimiko", "Kiyomi", "Kohana", "Kokoro", "Komako", "Kumiko", "Kyoko", "Madoka",
        "Maeko", "Maiko", "Mai", "Makiko", "Manami", "Mariko", "Masako", "Masami", "Mayumi", "Megumi",
        "Midori", "Mieko", "Miho", "Mika", "Mikako", "Miki", "Miku", "Minako", "Mio", "Misaki",
        "Misako", "Mitsuko", "Miyako", "Miyu", "Mizuki", "Momoko", "Motoko", "Naho", "Namiko", "Nanami",
        "Naoko", "Natsuki", "Nobuko", "Nozomi", "Oharu", "Okiku", "Orie", "Reiko", "Rie", "Rika",
        "Riko", "Rin", "Rina", "Sachiko", "Sae", "Saki", "Sakura", "Sanae", "Satsuki", "Sayaka",
        "Sayuri", "Seiko", "Shigeko", "Shino", "Shizuka", "Shizuko", "Sumiko", "Suzume", "Suzuko", "Taeko",
        "Takako", "Tamaki", "Tamiko", "Tatsuko", "Teruko", "Tokiko", "Tomiko", "Tomoe", "Toshiko", "Toyoko",
        "Tsukiko", "Umeko", "Ume", "Wakana", "Yae", "Yasuko", "Yayoi", "Yoko", "Yoriko", "Yoshie",
        "Yoshiko", "Yui", "Yuiko", "Yuka", "Yukari", "Yukiko", "Yumeko", "Yumi", "Yumiko", "Yuriko",
        "Yuu", "Yuuna", "Yuzuki", "Atsuko", "Chidori", "Fusae", "Ine", "Kinu", "Koto", "Mineko",
        "Naka", "Natsu", "Nene", "Oume", "Osen", "Otsuya", "Ritsu", "Sawa", "Suzu", "Tama",
        "Tokue", "Toyono", "Uta", "Yasu", "Yoshi", "Yotsuyu", "Chiyoha", "Tomoha", "Natsue", "Kinue",
        "Haruno", "Fuyumi", "Minami", "Kazuno", "Tokino", "Asuha", "Namie", "Shima", "Kureha", "Saya"
    };
    #endregion

    public static string GetFamilyName()
    {
        return familyNames[SW.Random.Integer(0, familyNames.Length)];
    }

    public static string GetGivenName(Sex sex)
    {
        return (sex == Sex.Female)
            ? femaleNames[SW.Random.Integer(0, femaleNames.Length)]
            : maleNames[SW.Random.Integer(0, maleNames.Length)];
    }
}