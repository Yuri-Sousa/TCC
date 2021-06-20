// ** I18N
Calendar._DN = new Array
("日",
 "月",
 "火",
 "水",
 "木",
 "金",
 "土",
 "日");
Calendar._MN = new Array
("1月",
 "2月",
 "3月",
 "4月",
 "5月",
 "6月",
 "7月",
 "8月",
 "9月",
 "10月",
 "11月",
 "12月");

// tooltips
Calendar._TT = {};
Calendar._TT["INFO"] = "カレンダーについて";
Calendar._TT["ABOUT"] =
"DHTML日付/時間の選択\n" +
"(c) dynarch.com 2002-2003\n" + // don't translate this this ;-)
"最新版: http://dynarch.com/mishoo/calendar.epl : \n" +
"GNU LGPLの下での配布は下記詳細を参照  http://gnu.org/licenses/lgpl.html " +
"\n\n" +
"日付選択方法\n" +
"- \xab, \xbbボタンで年を選択\n" +
"- " + String.fromCharCode(0x2039) + ", " + String.fromCharCode(0x203a) + String.fromCharCode(0x2039) + ", " + String.fromCharCode(0x203a) + " で月を選択\n" +
"- ボタンを押下し続ければ、一覧が表示されます";
Calendar._TT["ABOUT_TIME"] = "\n\n" +
"時間選択方法\n" +
"-時間の箇所をクリックして時間を進める\n" +
"-または、シフト＋クリックで時間を戻す\n" +
"-または、クリックしたままドラッグして一覧から選択";
Calendar._TT["TIME_PART"] = "(ｼﾌﾄ+)クリック";
Calendar._TT["TOGGLE"] = "週の最初の曜日を切り替え";
Calendar._TT["PREV_YEAR"] = "前年";
Calendar._TT["PREV_MONTH"] = "前月";
Calendar._TT["GO_TODAY"] = "今日";
Calendar._TT["NEXT_MONTH"] = "翌月";
Calendar._TT["NEXT_YEAR"] = "翌年";
Calendar._TT["SEL_DATE"] = "日付選択";
Calendar._TT["DATE_SELECTOR"] = "日付選択";
Calendar._TT["CLEAR_DATE"] = "クリア";
Calendar._TT["DRAG_TO_MOVE"] = "ウィンドウの移動";
Calendar._TT["PART_TODAY"] = " (今日)";
Calendar._TT["MON_FIRST"] = "月曜日を先頭に";
Calendar._TT["SUN_FIRST"] = "日曜日を先頭に";
Calendar._TT["CLOSE"] = "閉じる";
Calendar._TT["TODAY"] = "今日";

// date formats
Calendar._TT["DEF_DATE_FORMAT"] = "%Y年%b%e日";
Calendar._TT["TT_DATE_FORMAT"] = "%Y年%b%e日";

Calendar._TT["WK"] = "週";
