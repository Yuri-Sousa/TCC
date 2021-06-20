function Loader($) {
  var tloader = {};

  this.show = function() {
    this.Create();
  }

  this.Refresh = function() {
    this.Create();
  }

  this.SetImage = function(data) {
    this.Image = data;
  }

  this.GetImage = function() {
    return this.Image;
  }

  this.Insert = function() {
    if (!$(".gx-mask")[0]) {
      $("body").append("<div class='gx-mask'></div>");
    }
  }

  this.Remove = function() {
    if ($(".gx-mask")[0]) {
      $(".gx-mask").remove();
    }
  }

  this.Color = function(color) {
    this.BaseColor = {Html: color};
  }

  this.SetImage = function(data) {
    this.Image = data;
  }

  this.GetImage = function() {
    return this.Image;
  }

  this.Create = function() {
    this.Disc = this.BaseColor ? true : false;
    this.SetImage(this.GetImage() ? this.GetImage() : '4RLoader/Logo.svg');
    this.BaseColor = this.BaseColor ? {Html: toRgba(this.BaseColor.Html)} : {Html: toRgba('#FFFFFF')};
    this.BaseColor.Off = toRgba(this.BaseColor.Html, 0.2);

    switch (parseInt(this.Loader)) {
      case 0: // 'gradient'
        tloader.model = '<div class="gradient"><div class="gradient-img"></div>';
        tloader.model += this.Disc ? '<div class="gradient-spin"></div></div>' : '</div>';
      break;
      case 1: // 'disc'
        tloader.model = '<div class="disc"></div>';
      break;
      case 2: // 'disc-double'
        tloader.model = '<div class="disc disc-double"></div>';
      break;
      case 3: // 'pulse'
        tloader.model = '<div class="pulse"></div>';
      break;
      case 4: // 'cube'
        tloader.model = '<div class="cube"><div class="cube-slice slice1"></div><div class="cube-slice slice2"></div><div class="cube-slice slice4"></div><div class="cube-slice slice3"></div></div>';
      break;
      case 5: // 'modern'
        tloader.model = '<div class="modern"><div class="modern-slice slice1"></div><div class="modern-slice slice2"></div><div class="modern-slice slice3"></div></div>';
      break;
    }

    tloader.style = '.loader {top: calc(50% - '
    + joinSize(this.Size, 0.75) + '); left: calc(50% - '
    + joinSize(this.Size, 0.75) + '); } .gradient {width: '
    + joinSize(this.Size, 1.00) + '; height: ' + joinSize(this.Size, 1.00) + '; } '
    + '.gradient-img {background: transparent url("' + this.GetImage() + '") no-repeat center / 100% auto; } '
    + '.cube-slice::before {background: ' + this.BaseColor.Html + '; } '
    + ".gradient-spin { background: url('data:image/svg+xml,%3C%3Fxml%20version%3D%221.0%22%20encoding%3D%22utf-8%22%3F%3E%0D%0A%3Csvg%20version%3D%221.0%22%20id%3D%22Layer_1%22%20xmlns%3D%22http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg%22%20xmlns%3Axlink%3D%22http%3A%2F%2Fwww.w3.org%2F1999%2Fxlink%22%20x%3D%220px%22%20y%3D%220px%22%20width%3D%22100%25%22%20height%3D%22100%25%22%20viewBox%3D%220%200%20100%20100%22%20enable-background%3D%22new%200%200%20100%20100%22%20xml%3Aspace%3D%22preserve%22%3E%0D%0A%20%20%3Cpath%20d%3D%22M18.6%2C57.3c-0.5-2.3-0.8-4.8-0.8-7.3c0-17.8%2C14.4-32.2%2C32.2-32.2c0%2C0%2C0%2C0%2C0%2C0V0c0%2C0%2C0%2C0%2C0%2C0C22.4%2C0%2C0%2C22.4%2C0%2C50%0D%0A%20%20c0%2C2.5%2C0.2%2C4.9%2C0.5%2C7.3H18.6z%22%20fill%3D%22url(%23Gradient)%22%20%2F%3E%0D%0A%20%20%3Cdefs%3E%0D%0A%20%20%20%20%3ClinearGradient%20id%3D%22Gradient%22%20gradientTransform%3D%22rotate(40)%22%20x1%3D%220%25%22%20y1%3D%220%25%22%20x2%3D%220%25%22%20y2%3D%2250%25%22%3E%0D%0A%20%20%20%20%20%20%3Cstop%20offset%3D%220%25%22%20stop-color%3D%22%23" + toHex(this.BaseColor.Html) + "%22%20stop-opacity%3D%221%22%20%2F%3E%0D%0A%20%20%20%20%20%20%3Cstop%20offset%3D%22100%25%22%20stop-color%3D%22%23" + toHex(this.BaseColor.Html) + "%22%20stop-opacity%3D%220%22%20%2F%3E%0D%0A%20%20%20%20%3C%2FlinearGradient%3E%0D%0A%20%20%3C%2Fdefs%3E%0D%0A%3C%2Fsvg%3E') } "
    + '.disc {width: '
    + joinSize(this.Size, 1.00) + '; height: '
    + joinSize(this.Size, 1.00) + '; border: '
    + joinSize(this.Size, 0.25) + ' solid '
    +this.BaseColor.Off + '; border-top-color: '
    + this.BaseColor.Html + '; } .disc-double {border-style: double; } .pulse {position: relative; width: '
    + joinSize(this.Size, 0.20) + '; height: '
    + joinSize(this.Size, 1.00) + '; margin: 0 '
    + joinSize(this.Size, 0.40) + '; } .pulse::before, .pulse::after {width: '
    + joinSize(this.Size, 0.20) + '; height: '
    + joinSize(this.Size, 0.75) + '; } .pulse::before {left: -'
    + joinSize(this.Size, 0.40) + '; } .pulse::after {left: '
    + joinSize(this.Size, 0.40) + '; } .pulse, .pulse::before, .pulse::after {background: '
    +this.BaseColor.Off + '; } .cube {width: '
    + joinSize(this.Size, 1.00) + '; height: '
    + joinSize(this.Size, 1.00) + '; } .modern {left: calc(50% - '
    + joinSize(this.Size, 0.50) + '); width: '
    + joinSize(this.Size, 1.00) + '; height: '
    + joinSize(this.Size, 1.00) + '; } .modern-slice {border-color: '
    + this.BaseColor.Html + '; } @keyframes pulse { 50% { background: '
    + this.BaseColor.Html + '; } }';
  }

  $(document).bind("DOMNodeInserted",function(e){
    if ($(e.target).hasClass("gx-mask")) {
      if (!$('.loader')[0]) {
        $('head').append('<style id="loader">'+tloader.style+'</style>');
        $(e.target).before('<div class="loader">'+tloader.model+'</div>');
      }
    }
  });

  $(document).bind("DOMNodeRemoved",function(e){
    if ($(e.target).hasClass("gx-mask")) {
      if ($('.loader')[0]) {
        $('.loader').remove();
        $('#loader').remove();
      }
    }
  });

  function joinSize(size, perc) {
    var arr = size;
    arr = toSize(arr) ? toSize(arr) : [70, 'px']
    arr[0] = (arr[0] * perc).toString();
    return arr.join('');
  }

  function toSize(size) {
    var result = /^(\d*\.?\d*?)([a-z]{1,4})?$/i.exec(size);
    return result ? [ parseFloat(result[1]), result[2] ? result[2] : 'px'] : null;
  }

  function toHex(color) {
    if (/^#?([a-f\d]{3})$/i.exec(color))
      color = '#' + /^#?([a-f\d]{3})$/i.exec(color)[1] + /^#?([a-f\d]{3})$/i.exec(color)[1].slice(0,3);
    var hex = /^#?([a-f\d]{2})([a-f\d]{2})([a-f\d]{2})$/i.exec(color);
    hex = hex ? [ parseInt(hex[1], 16), parseInt(hex[2], 16), parseInt(hex[3], 16) ]: null;
    var rgba = /^r?g?b?.?\((\d*), ?(\d{1,3}), ?(\d{1,3}),? ?(\d*?\.?\d*?)\)?$/i.exec(color);
    rgba = !rgba ? /^r?g?b?.?\(?^(\d*), ?(\d{1,3}), ?(\d{1,3}),? ?(\d*?\.?\d*?)\)?$/i.exec(color) : rgba;
    rgba = (!hex && rgba) ? [ parseInt(rgba[1]), parseInt(rgba[2]), parseInt(rgba[3]) ] : hex;
    rgba = $.map(rgba, function(v) { return v.toString(16).length == 1 ? "0" + v.toString(16) : v.toString(16); });
    return rgba ? rgba.join('').toUpperCase() : color.replace('#', '');
  }

  function toRgba(color, opacity) {
    if (/^#?([a-f\d]{3})$/i.exec(color))
      color = '#' + /^#?([a-f\d]{3})$/i.exec(color)[1] + /^#?([a-f\d]{3})$/i.exec(color)[1].slice(0,3);
    var hex = /^#?([a-f\d]{2})([a-f\d]{2})([a-f\d]{2})$/i.exec(color);
    hex = hex ? [ parseInt(hex[1], 16), parseInt(hex[2], 16), parseInt(hex[3], 16), opacity ? opacity : 1 ]: null;
    var rgba = /^r?g?b?.?\((\d{1,3}), ?(\d{1,3}), ?(\d{1,3}),? ?(\d*?\.?\d*?)\)?$/i.exec(color);
    rgba = !rgba ? /^r?g?b?.?\(?^(\d*), ?(\d{1,3}), ?(\d{1,3}),? ?(\d*?\.?\d*?)\)?$/i.exec(color) : rgba;
    rgba = (!hex && rgba) ? [ parseFloat(rgba[1]), parseFloat(rgba[2]), parseFloat(rgba[3]), opacity ? opacity : (rgba[4] ? parseFloat(rgba[4]) : 1)] : hex;
    return rgba ?  'rgba(' + [ rgba[0], rgba[1], rgba[2], rgba[3] ].join(', ') + ')'  : color;
  }
}
