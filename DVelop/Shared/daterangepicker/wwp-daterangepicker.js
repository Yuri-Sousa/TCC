﻿function WWP_DateRangePicker(n,t,i){function l(n){var t={},h,o,r;if(t.alwaysShowCalendars=!0,n===undefined)return t;h=e(t,n,"startDate","StartDate");e(t,n,"endDate","EndDate");e(t,n,"minDate","MinDate");e(t,n,"maxDate","MaxDate");t.parentEl=null;e(t,n,"parentEl","parentEl");e(t,n,"flatDisplay","flatDisplay",!1);u(t,n,"showDropdowns","DatePicker.ShowDropdowns",!0);u(t,n,"minYear","DatePicker.MinYear");u(t,n,"maxYear","DatePicker.MaxYear");u(t,n,"showWeekNumbers","DatePicker.ShowWeekNumbers");u(t,n,"singleDatePicker","DatePicker.SingleDatePicker",!1);u(t,n,"linkedCalendars","DatePicker.LinkedCalendars",!0);var c=u(t,n,"timePicker","TimePicker.Show",!1),f=u(t,n,"timePicker24Hour","TimePicker.Hour24"),l=u(t,n,"timePickerSeconds","TimePicker.ShowSeconds");u(t,n,"timePickerIncrement","TimePicker.Increment");u(t,n,"drops","Advanced.Drops","auto");u(t,n,"opens","Advanced.OpenLocation");u(t,n,"autoApply","Advanced.AutoApply");o=u(t,n,"showCustomRangeLabel","ShowCustomRangeLabel",!0);o||(t.alwaysShowCalendars=!1);t.autoUpdateInput=!1;var i=n.Locale,y=i&&i.Id?i.id:null,s=i&&i.Format?i.Format:null;v(t,y);t.locale.format=s?i.Format:defaultWWPDateRangeSettings.dateFormat?defaultWWPDateRangeSettings.dateFormat:t.locale.format;c&&!s&&(t.locale.format+=f?" HH:mm":" hh:mm",l&&(t.locale.format+=":ss"),f&&(t.locale.format+=" A"));switch(n.PickerType){case"single":t.singleDatePicker=!0}return a(t,n),r=$.extend(defaultWWPDateRangeSettings,t),r.optsLoaded||(r.settingsBeforeMerge=t),r}function a(n,t){var i=t.Ranges,f={},r,u;if(i&&i.length>0){for(r=0;r<i.length;r++)u=i[r],f[u.DisplayName]=[new Date(u.StartDate),new Date(u.EndDate)];n.ranges=f}}function v(n,t){var u=window.WWP_DateRangePicker_Locales,r,i;t||(r={eng:"English",spa:"Spanish",por:"Portuguese",ita:"Italian",german:"German",chs:"SimplifiedChinese",cht:"TraditionalChinese",jap:"Japanese",Arabic:"Arabic"},t=r[gx.languageCode]);t?(i=JSON.parse(JSON.stringify(u[t])),i?n.locale=i:(console.error("WWP_DateRangePicker_UC: Locale not found in resources: "+t),console.log("WWP_DateRangePicker_UC: Using default locale"))):(console.log("WWP_DateRangePicker_UC: LocaleId not found for : "+t||gx.languageCode),console.log("WWP_DateRangePicker_UC: Using default locale"))}function u(n,t,i,r,u){for(var o=r.split("."),f=t,s=u,e=0;e<o.length-1&&f;e++)f=f[o[e]];return f!=undefined&&f[o[e]]!=undefined&&(s=f[o[e]]),s!=undefined&&(n[i]=s),s}function e(n,t,i,r,f){return u(n,t,i,r,f),typeof n[i]=="string"&&(n[i]=new Date(n[i])),n[i]}var h,r,f;if(n==="")throw"WWP_DateRangePicker_UC.Attach: Selector cannot be empty";if(t==undefined&&console.log("WWP_DateRangePicker_UC: Initializing with default options"),r=$(n),r=r.length===0?$("#"+n):r,r.length===0)throw new"WWP_DateRangePicker_UC.Attach: Selector not found: "+n;var c=l(t),o=r[0],s=function(n,t){setTimeout(function(){n.isShowing=!0;gx.fn.setFocus(t,function(){n.isShowing=!1})},10)};r.daterangepicker(c,function(n,t,r,u){i!=undefined&&(r=r!==h.customRangeLabel?r:null,i(n.toDate(),t.toDate(),r,u));var e=$(u.currentTarget).parents(".daterangepicker").length>0;e&&s(f,o)}).on("cancel.daterangepicker",function(n,t){t.isNullVal=!0;t.setStartDate(new Date);t.setEndDate(new Date);r.val("");i!=undefined&&i(null,null,null,n);s(t,o)}).on("apply.daterangepicker",function(n,t){var u=r.val(),f=new gx.date.gxdate(u);t.isNullVal=gx.date.isNullDate(f);(t.flatDisplay||t.isNullVal&&t.startDate.isSame(t.oldStartDate))&&i(t.startDate.toDate(),t.endDate.toDate(),null,n);s(t,o)});f=r.data("daterangepicker");r.toggleClass(WWP_DateRangePicker_INPUT_CSS_CLASS,!0);r.on("change",function(n){var t=$(this).val();(t===""||typeof n==KeyboardEvent)&&i!=undefined&&i(null,null,"",n);f.startDate.isValid()&&f.endDate.isValid()||f.clickCancel()});r.on("input",function(n){f.show(n)});h=r.data("daterangepicker").locale;this.setStartDate=function(n){r.data("daterangepicker").setStartDate(n)};this.setEndDate=function(n){r.data("daterangepicker").setEndDate(n)}}var WWP_DateRangePicker_INPUT_CSS_CLASS="wwp-daterange-picker-input",WWP_DateRangePicker_DATE_RANGE=[1970,2040],defaultWWPDateRangeSettings={minYear:WWP_DateRangePicker_DATE_RANGE[0],maxYear:WWP_DateRangePicker_DATE_RANGE[1],autoApply:!0,showWeekNumbers:!1,showDropdowns:!0,style:"Light"},mapGXDateFormatToDatePickerFormat=function(n){var t=n;return t=t.replace("%m","MM"),t=t.replace("%d","DD"),t=t.replace("%y","YY"),t=t.replace("%Y","YYYY"),n.indexOf("%p")>0?(t=t.replace("%I","h"),t=t.replace("%p","A")):t=t.replace("%I","HH"),t=t.replace("%H","HH"),t=t.replace("%M","mm"),t.replace("%S","ss")};$(window).one('load',function(){WWP_VV([['WWP.DatePicker','14.1000'],['WWP.DateRangePicker','14.3']]);});