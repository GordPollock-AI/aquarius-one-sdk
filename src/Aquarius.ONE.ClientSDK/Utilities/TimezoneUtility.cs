﻿using System;
using System.Collections.Generic;
using System.Linq;
using ONE.Models.CSharp;

namespace ONE.Utilities
{
    public class TimezoneUtility
    {
        private static Dictionary<int, string> _timezones;

        public static Dictionary<int, string> Timezones
        {
            get
            {
                if (_timezones == null)
                {
                    _timezones = new Dictionary<int, string>
                    {
                        {1, "Africa/Abidjan"},
                        {2, "Africa/Accra"},
                        {3, "Africa/Addis_Ababa"},
                        {4, "Africa/Algiers"},
                        {5, "Africa/Asmara"},
                        {6, "Africa/Bamako"},
                        {7, "Africa/Bangui"},
                        {8, "Africa/Banjul"},
                        {9, "Africa/Bissau"},
                        {10, "Africa/Blantyre"},
                        {11, "Africa/Brazzaville"},
                        {12, "Africa/Bujumbura"},
                        {13, "Africa/Cairo"},
                        {14, "Africa/Casablanca"},
                        {15, "Africa/Ceuta"},
                        {16, "Africa/Conakry"},
                        {17, "Africa/Dakar"},
                        {18, "Africa/Dar_es_Salaam"},
                        {19, "Africa/Djibouti"},
                        {20, "Africa/Douala"},
                        {21, "Africa/El_Aaiun"},
                        {22, "Africa/Freetown"},
                        {23, "Africa/Gaborone"},
                        {24, "Africa/Harare"},
                        {25, "Africa/Johannesburg"},
                        {26, "Africa/Juba"},
                        {27, "Africa/Kampala"},
                        {28, "Africa/Khartoum"},
                        {29, "Africa/Kigali"},
                        {30, "Africa/Kinshasa"},
                        {31, "Africa/Lagos"},
                        {32, "Africa/Libreville"},
                        {33, "Africa/Lome"},
                        {34, "Africa/Luanda"},
                        {35, "Africa/Lubumbashi"},
                        {36, "Africa/Lusaka"},
                        {37, "Africa/Malabo"},
                        {38, "Africa/Maputo"},
                        {39, "Africa/Maseru"},
                        {40, "Africa/Mbabane"},
                        {41, "Africa/Mogadishu"},
                        {42, "Africa/Monrovia"},
                        {43, "Africa/Nairobi"},
                        {44, "Africa/Ndjamena"},
                        {45, "Africa/Niamey"},
                        {46, "Africa/Nouakchott"},
                        {47, "Africa/Ouagadougou"},
                        {48, "Africa/Porto-Novo"},
                        {49, "Africa/Sao_Tome"},
                        {50, "Africa/Timbuktu"},
                        {51, "Africa/Tripoli"},
                        {52, "Africa/Tunis"},
                        {53, "Africa/Windhoek"},
                        {54, "America/Adak"},
                        {55, "America/Anchorage"},
                        {56, "America/Anguilla"},
                        {57, "America/Antigua"},
                        {58, "America/Araguaina"},
                        {59, "America/Argentina/Buenos_Aires"},
                        {60, "America/Argentina/Catamarca"},
                        {61, "America/Argentina/ComodRivadavia"},
                        {62, "America/Argentina/Cordoba"},
                        {63, "America/Argentina/Jujuy"},
                        {64, "America/Argentina/La_Rioja"},
                        {65, "America/Argentina/Mendoza"},
                        {66, "America/Argentina/Rio_Gallegos"},
                        {67, "America/Argentina/Salta"},
                        {68, "America/Argentina/San_Juan"},
                        {69, "America/Argentina/San_Luis"},
                        {70, "America/Argentina/Tucuman"},
                        {71, "America/Argentina/Ushuaia"},
                        {72, "America/Aruba"},
                        {73, "America/Asuncion"},
                        {74, "America/Atikokan"},
                        {75, "America/Atka"},
                        {76, "America/Bahia"},
                        {77, "America/Bahia_Banderas"},
                        {78, "America/Barbados"},
                        {79, "America/Belem"},
                        {80, "America/Belize"},
                        {81, "America/Blanc-Sablon"},
                        {82, "America/Boa_Vista"},
                        {83, "America/Bogota"},
                        {84, "America/Boise"},
                        {85, "America/Buenos_Aires"},
                        {86, "America/Cambridge_Bay"},
                        {87, "America/Campo_Grande"},
                        {88, "America/Cancun"},
                        {89, "America/Caracas"},
                        {90, "America/Catamarca"},
                        {91, "America/Cayenne"},
                        {92, "America/Cayman"},
                        {93, "America/Chicago"},
                        {94, "America/Chihuahua"},
                        {95, "America/Coral_Harbour"},
                        {96, "America/Cordoba"},
                        {97, "America/Costa_Rica"},
                        {98, "America/Creston"},
                        {99, "America/Cuiaba"},
                        {100, "America/Curacao"},
                        {101, "America/Danmarkshavn"},
                        {102, "America/Dawson"},
                        {103, "America/Dawson_Creek"},
                        {104, "America/Denver"},
                        {105, "America/Detroit"},
                        {106, "America/Dominica"},
                        {107, "America/Edmonton"},
                        {108, "America/Eirunepe"},
                        {109, "America/El_Salvador"},
                        {110, "America/Ensenada"},
                        {111, "America/Fort_Nelson"},
                        {112, "America/Fort_Wayne"},
                        {113, "America/Fortaleza"},
                        {114, "America/Glace_Bay"},
                        {115, "America/Godthab"},
                        {116, "America/Goose_Bay"},
                        {117, "America/Grand_Turk"},
                        {118, "America/Grenada"},
                        {119, "America/Guadeloupe"},
                        {120, "America/Guatemala"},
                        {121, "America/Guayaquil"},
                        {122, "America/Guyana"},
                        {123, "America/Halifax"},
                        {124, "America/Havana"},
                        {125, "America/Hermosillo"},
                        {126, "America/Indiana/Indianapolis"},
                        {127, "America/Indiana/Knox"},
                        {128, "America/Indiana/Marengo"},
                        {129, "America/Indiana/Petersburg"},
                        {130, "America/Indiana/Tell_City"},
                        {131, "America/Indiana/Vevay"},
                        {132, "America/Indiana/Vincennes"},
                        {133, "America/Indiana/Winamac"},
                        {134, "America/Indianapolis"},
                        {135, "America/Inuvik"},
                        {136, "America/Iqaluit"},
                        {137, "America/Jamaica"},
                        {138, "America/Jujuy"},
                        {139, "America/Juneau"},
                        {140, "America/Kentucky/Louisville"},
                        {141, "America/Kentucky/Monticello"},
                        {142, "America/Knox_IN"},
                        {143, "America/Kralendijk"},
                        {144, "America/La_Paz"},
                        {145, "America/Lima"},
                        {146, "America/Los_Angeles"},
                        {147, "America/Louisville"},
                        {148, "America/Lower_Princes"},
                        {149, "America/Maceio"},
                        {150, "America/Managua"},
                        {151, "America/Manaus"},
                        {152, "America/Marigot"},
                        {153, "America/Martinique"},
                        {154, "America/Matamoros"},
                        {155, "America/Mazatlan"},
                        {156, "America/Mendoza"},
                        {157, "America/Menominee"},
                        {158, "America/Merida"},
                        {159, "America/Metlakatla"},
                        {160, "America/Mexico_City"},
                        {161, "America/Miquelon"},
                        {162, "America/Moncton"},
                        {163, "America/Monterrey"},
                        {164, "America/Montevideo"},
                        {165, "America/Montreal"},
                        {166, "America/Montserrat"},
                        {167, "America/Nassau"},
                        {168, "America/New_York"},
                        {169, "America/Nipigon"},
                        {170, "America/Nome"},
                        {171, "America/Noronha"},
                        {172, "America/North_Dakota/Beulah"},
                        {173, "America/North_Dakota/Center"},
                        {174, "America/North_Dakota/New_Salem"},
                        {175, "America/Ojinaga"},
                        {176, "America/Panama"},
                        {177, "America/Pangnirtung"},
                        {178, "America/Paramaribo"},
                        {179, "America/Phoenix"},
                        {180, "America/Port_of_Spain"},
                        {181, "America/Port-au-Prince"},
                        {182, "America/Porto_Acre"},
                        {183, "America/Porto_Velho"},
                        {184, "America/Puerto_Rico"},
                        {185, "America/Punta_Arenas"},
                        {186, "America/Rainy_River"},
                        {187, "America/Rankin_Inlet"},
                        {188, "America/Recife"},
                        {189, "America/Regina"},
                        {190, "America/Resolute"},
                        {191, "America/Rio_Branco"},
                        {192, "America/Rosario"},
                        {193, "America/Santa_Isabel"},
                        {194, "America/Santarem"},
                        {195, "America/Santiago"},
                        {196, "America/Santo_Domingo"},
                        {197, "America/Sao_Paulo"},
                        {198, "America/Scoresbysund"},
                        {199, "America/Shiprock"},
                        {200, "America/Sitka"},
                        {201, "America/St_Barthelemy"},
                        {202, "America/St_Johns"},
                        {203, "America/St_Kitts"},
                        {204, "America/St_Lucia"},
                        {205, "America/St_Thomas"},
                        {206, "America/St_Vincent"},
                        {207, "America/Swift_Current"},
                        {208, "America/Tegucigalpa"},
                        {209, "America/Thule"},
                        {210, "America/Thunder_Bay"},
                        {211, "America/Tijuana"},
                        {212, "America/Toronto"},
                        {213, "America/Tortola"},
                        {214, "America/Vancouver"},
                        {215, "America/Virgin"},
                        {216, "America/Whitehorse"},
                        {217, "America/Winnipeg"},
                        {218, "America/Yakutat"},
                        {219, "America/Yellowknife"},
                        {220, "Antarctica/Casey"},
                        {221, "Antarctica/Davis"},
                        {222, "Antarctica/DumontDUrville"},
                        {223, "Antarctica/Macquarie"},
                        {224, "Antarctica/Mawson"},
                        {225, "Antarctica/McMurdo"},
                        {226, "Antarctica/Palmer"},
                        {227, "Antarctica/Rothera"},
                        {228, "Antarctica/South_Pole"},
                        {229, "Antarctica/Syowa"},
                        {230, "Antarctica/Troll"},
                        {231, "Antarctica/Vostok"},
                        {232, "Arctic/Longyearbyen"},
                        {233, "Asia/Aden"},
                        {234, "Asia/Almaty"},
                        {235, "Asia/Amman"},
                        {236, "Asia/Anadyr"},
                        {237, "Asia/Aqtau"},
                        {238, "Asia/Aqtobe"},
                        {239, "Asia/Ashgabat"},
                        {240, "Asia/Ashkhabad"},
                        {241, "Asia/Atyrau"},
                        {242, "Asia/Baghdad"},
                        {243, "Asia/Bahrain"},
                        {244, "Asia/Baku"},
                        {245, "Asia/Bangkok"},
                        {246, "Asia/Barnaul"},
                        {247, "Asia/Beirut"},
                        {248, "Asia/Bishkek"},
                        {249, "Asia/Brunei"},
                        {250, "Asia/Calcutta"},
                        {251, "Asia/Chita"},
                        {252, "Asia/Choibalsan"},
                        {253, "Asia/Chongqing"},
                        {254, "Asia/Chungking"},
                        {255, "Asia/Colombo"},
                        {256, "Asia/Dacca"},
                        {257, "Asia/Damascus"},
                        {258, "Asia/Dhaka"},
                        {259, "Asia/Dili"},
                        {260, "Asia/Dubai"},
                        {261, "Asia/Dushanbe"},
                        {262, "Asia/Famagusta"},
                        {263, "Asia/Gaza"},
                        {264, "Asia/Harbin"},
                        {265, "Asia/Hebron"},
                        {266, "Asia/Ho_Chi_Minh"},
                        {267, "Asia/Hong_Kong"},
                        {268, "Asia/Hovd"},
                        {269, "Asia/Irkutsk"},
                        {270, "Asia/Istanbul"},
                        {271, "Asia/Jakarta"},
                        {272, "Asia/Jayapura"},
                        {273, "Asia/Jerusalem"},
                        {274, "Asia/Kabul"},
                        {275, "Asia/Kamchatka"},
                        {276, "Asia/Karachi"},
                        {277, "Asia/Kashgar"},
                        {278, "Asia/Kathmandu"},
                        {279, "Asia/Katmandu"},
                        {280, "Asia/Khandyga"},
                        {281, "Asia/Kolkata"},
                        {282, "Asia/Krasnoyarsk"},
                        {283, "Asia/Kuala_Lumpur"},
                        {284, "Asia/Kuching"},
                        {285, "Asia/Kuwait"},
                        {286, "Asia/Macao"},
                        {287, "Asia/Macau"},
                        {288, "Asia/Magadan"},
                        {289, "Asia/Makassar"},
                        {290, "Asia/Manila"},
                        {291, "Asia/Muscat"},
                        {292, "Asia/Novokuznetsk"},
                        {293, "Asia/Novosibirsk"},
                        {294, "Asia/Omsk"},
                        {295, "Asia/Oral"},
                        {296, "Asia/Phnom_Penh"},
                        {297, "Asia/Pontianak"},
                        {298, "Asia/Pyongyang"},
                        {299, "Asia/Qatar"},
                        {300, "Asia/Qyzylorda"},
                        {301, "Asia/Rangoon"},
                        {302, "Asia/Riyadh"},
                        {303, "Asia/Saigon"},
                        {304, "Asia/Sakhalin"},
                        {305, "Asia/Samarkand"},
                        {306, "Asia/Seoul"},
                        {307, "Asia/Shanghai"},
                        {308, "Asia/Singapore"},
                        {309, "Asia/Srednekolymsk"},
                        {310, "Asia/Taipei"},
                        {311, "Asia/Tashkent"},
                        {312, "Asia/Tbilisi"},
                        {313, "Asia/Tehran"},
                        {314, "Asia/Tel_Aviv"},
                        {315, "Asia/Thimbu"},
                        {316, "Asia/Thimphu"},
                        {317, "Asia/Tokyo"},
                        {318, "Asia/Tomsk"},
                        {319, "Asia/Ujung_Pandang"},
                        {320, "Asia/Ulaanbaatar"},
                        {321, "Asia/Ulan_Bator"},
                        {322, "Asia/Urumqi"},
                        {323, "Asia/Ust-Nera"},
                        {324, "Asia/Vientiane"},
                        {325, "Asia/Vladivostok"},
                        {326, "Asia/Yakutsk"},
                        {327, "Asia/Yangon"},
                        {328, "Asia/Yekaterinburg"},
                        {329, "Asia/Yerevan"},
                        {330, "Atlantic/Azores"},
                        {331, "Atlantic/Bermuda"},
                        {332, "Atlantic/Canary"},
                        {333, "Atlantic/Cape_Verde"},
                        {334, "Atlantic/Faeroe"},
                        {335, "Atlantic/Faroe"},
                        {336, "Atlantic/Jan_Mayen"},
                        {337, "Atlantic/Madeira"},
                        {338, "Atlantic/Reykjavik"},
                        {339, "Atlantic/South_Georgia"},
                        {340, "Atlantic/St_Helena"},
                        {341, "Atlantic/Stanley"},
                        {342, "Australia/ACT"},
                        {343, "Australia/Adelaide"},
                        {344, "Australia/Brisbane"},
                        {345, "Australia/Broken_Hill"},
                        {346, "Australia/Canberra"},
                        {347, "Australia/Currie"},
                        {348, "Australia/Darwin"},
                        {349, "Australia/Eucla"},
                        {350, "Australia/Hobart"},
                        {351, "Australia/LHI"},
                        {352, "Australia/Lindeman"},
                        {353, "Australia/Lord_Howe"},
                        {354, "Australia/Melbourne"},
                        {355, "Australia/North"},
                        {356, "Australia/NSW"},
                        {357, "Australia/Perth"},
                        {358, "Australia/Queensland"},
                        {359, "Australia/South"},
                        {360, "Australia/Sydney"},
                        {361, "Australia/Tasmania"},
                        {362, "Australia/Victoria"},
                        {363, "Australia/West"},
                        {364, "Australia/Yancowinna"},
                        {365, "Brazil/Acre"},
                        {366, "Brazil/DeNoronha"},
                        {367, "Brazil/East"},
                        {368, "Brazil/West"},
                        {369, "Canada/Atlantic"},
                        {370, "Canada/Central"},
                        {371, "Canada/Eastern"},
                        {372, "Canada/Mountain"},
                        {373, "Canada/Newfoundland"},
                        {374, "Canada/Pacific"},
                        {375, "Canada/Saskatchewan"},
                        {376, "Canada/Yukon"},
                        {377, "CET"},
                        {378, "Chile/Continental"},
                        {379, "Chile/EasterIsland"},
                        {380, "CST6CDT"},
                        {381, "Cuba"},
                        {382, "EET"},
                        {383, "Egypt"},
                        {384, "Eire"},
                        {385, "EST"},
                        {386, "EST5EDT"},
                        {387, "Etc/GMT"},
                        {417, "Etc/Greenwich"},
                        {418, "Etc/UCT"},
                        {419, "Etc/Universal"},
                        {420, "Etc/UTC"},
                        {421, "Etc/Zulu"},
                        {422, "Europe/Amsterdam"},
                        {423, "Europe/Andorra"},
                        {424, "Europe/Astrakhan"},
                        {425, "Europe/Athens"},
                        {426, "Europe/Belfast"},
                        {427, "Europe/Belgrade"},
                        {428, "Europe/Berlin"},
                        {429, "Europe/Bratislava"},
                        {430, "Europe/Brussels"},
                        {431, "Europe/Bucharest"},
                        {432, "Europe/Budapest"},
                        {433, "Europe/Busingen"},
                        {434, "Europe/Chisinau"},
                        {435, "Europe/Copenhagen"},
                        {436, "Europe/Dublin"},
                        {437, "Europe/Gibraltar"},
                        {438, "Europe/Guernsey"},
                        {439, "Europe/Helsinki"},
                        {440, "Europe/Isle_of_Man"},
                        {441, "Europe/Istanbul"},
                        {442, "Europe/Jersey"},
                        {443, "Europe/Kaliningrad"},
                        {444, "Europe/Kiev"},
                        {445, "Europe/Kirov"},
                        {446, "Europe/Lisbon"},
                        {447, "Europe/Ljubljana"},
                        {448, "Europe/London"},
                        {449, "Europe/Luxembourg"},
                        {450, "Europe/Madrid"},
                        {451, "Europe/Malta"},
                        {452, "Europe/Mariehamn"},
                        {453, "Europe/Minsk"},
                        {454, "Europe/Monaco"},
                        {455, "Europe/Moscow"},
                        {456, "Asia/Nicosia"},
                        {457, "Europe/Oslo"},
                        {458, "Europe/Paris"},
                        {459, "Europe/Podgorica"},
                        {460, "Europe/Prague"},
                        {461, "Europe/Riga"},
                        {462, "Europe/Rome"},
                        {463, "Europe/Samara"},
                        {464, "Europe/San_Marino"},
                        {465, "Europe/Sarajevo"},
                        {466, "Europe/Saratov"},
                        {467, "Europe/Simferopol"},
                        {468, "Europe/Skopje"},
                        {469, "Europe/Sofia"},
                        {470, "Europe/Stockholm"},
                        {471, "Europe/Tallinn"},
                        {472, "Europe/Tirane"},
                        {473, "Europe/Tiraspol"},
                        {474, "Europe/Ulyanovsk"},
                        {475, "Europe/Uzhgorod"},
                        {476, "Europe/Vaduz"},
                        {477, "Europe/Vatican"},
                        {478, "Europe/Vienna"},
                        {479, "Europe/Vilnius"},
                        {480, "Europe/Volgograd"},
                        {481, "Europe/Warsaw"},
                        {482, "Europe/Zagreb"},
                        {483, "Europe/Zaporozhye"},
                        {484, "Europe/Zurich"},
                        {485, "GB"},
                        {486, "GB-Eire"},
                        {487, "GMT"},
                        {488, "GMT+0"},
                        {489, "GMT0"},
                        {490, "GMT−0"},
                        {491, "Greenwich"},
                        {492, "Hongkong"},
                        {493, "HST"},
                        {494, "Iceland"},
                        {495, "Indian/Antananarivo"},
                        {496, "Indian/Chagos"},
                        {497, "Indian/Christmas"},
                        {498, "Indian/Cocos"},
                        {499, "Indian/Comoro"},
                        {500, "Indian/Kerguelen"},
                        {501, "Indian/Mahe"},
                        {502, "Indian/Maldives"},
                        {503, "Indian/Mauritius"},
                        {504, "Indian/Mayotte"},
                        {505, "Indian/Reunion"},
                        {506, "Iran"},
                        {507, "Israel"},
                        {508, "Jamaica"},
                        {509, "Japan"},
                        {510, "Kwajalein"},
                        {511, "Libya"},
                        {512, "MET"},
                        {513, "Mexico/BajaNorte"},
                        {514, "Mexico/BajaSur"},
                        {515, "Mexico/General"},
                        {516, "MST"},
                        {517, "MST7MDT"},
                        {518, "Navajo"},
                        {519, "NZ"},
                        {520, "NZ-CHAT"},
                        {521, "Pacific/Apia"},
                        {522, "Pacific/Auckland"},
                        {523, "Pacific/Bougainville"},
                        {524, "Pacific/Chatham"},
                        {525, "Pacific/Chuuk"},
                        {526, "Pacific/Easter"},
                        {527, "Pacific/Efate"},
                        {528, "Pacific/Enderbury"},
                        {529, "Pacific/Fakaofo"},
                        {530, "Pacific/Fiji"},
                        {531, "Pacific/Funafuti"},
                        {532, "Pacific/Galapagos"},
                        {533, "Pacific/Gambier"},
                        {534, "Pacific/Guadalcanal"},
                        {535, "Pacific/Guam"},
                        {536, "Pacific/Honolulu"},
                        {537, "Pacific/Johnston"},
                        {538, "Pacific/Kiritimati"},
                        {539, "Pacific/Kosrae"},
                        {540, "Pacific/Kwajalein"},
                        {541, "Pacific/Majuro"},
                        {542, "Pacific/Marquesas"},
                        {543, "Pacific/Midway"},
                        {544, "Pacific/Nauru"},
                        {545, "Pacific/Niue"},
                        {546, "Pacific/Norfolk"},
                        {547, "Pacific/Noumea"},
                        {548, "Pacific/Pago_Pago"},
                        {549, "Pacific/Palau"},
                        {550, "Pacific/Pitcairn"},
                        {551, "Pacific/Pohnpei"},
                        {552, "Pacific/Ponape"},
                        {553, "Pacific/Port_Moresby"},
                        {554, "Pacific/Rarotonga"},
                        {555, "Pacific/Saipan"},
                        {556, "Pacific/Samoa"},
                        {557, "Pacific/Tahiti"},
                        {558, "Pacific/Tarawa"},
                        {559, "Pacific/Tongatapu"},
                        {560, "Pacific/Truk"},
                        {561, "Pacific/Wake"},
                        {562, "Pacific/Wallis"}
                    };
                }

                return _timezones;
            }
        }

        /// <summary>
        /// For a given timezone name, returns the matched Claros Timezone
        /// </summary>
        /// <param name="name">TZ database name</param>
        /// <returns>Matched Claros.Common.Core.TimeZone, or TimeZone.TimezoneUnknown if not found</returns>
        public static EnumTimeZone GetTimezone(string name)
        {
            KeyValuePair<int, string> matched = Timezones.FirstOrDefault(t => t.Value.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (matched.Value == null)
                return EnumTimeZone.TimezoneUnknown;

            EnumTimeZone timezone = (EnumTimeZone)matched.Key;

            return timezone;
        }

    }
}
