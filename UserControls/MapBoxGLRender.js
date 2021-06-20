function MapBoxGL($) {
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  

	var template = '<!-- Dependencias MapBoxGL --><script src=\'https://api.mapbox.com/mapbox-gl-js/v1.11.1/mapbox-gl.js\'></script><link href=\'https://api.mapbox.com/mapbox-gl-js/v1.11.1/mapbox-gl.css\' rel=\'stylesheet\' /><!-- Dependencias Geocoder (Barra de busca) --><script src=\"https://api.mapbox.com/mapbox-gl-js/plugins/mapbox-gl-geocoder/v4.5.1/mapbox-gl-geocoder.min.js\"></script><link rel=\"stylesheet\" href=\"https://api.mapbox.com/mapbox-gl-js/plugins/mapbox-gl-geocoder/v4.5.1/mapbox-gl-geocoder.css\" type=\"text/css\"/><!-- Promise polyfill script required to use Mapbox GL Geocoder in IE 11 --><script src=\"https://cdn.jsdelivr.net/npm/es6-promise@4/dist/es6-promise.min.js\"></script><script src=\"https://cdn.jsdelivr.net/npm/es6-promise@4/dist/es6-promise.auto.min.js\"></script><!-- Dependencias Draw MapBoxGL --><link rel=\'stylesheet\' href=\'https://api.mapbox.com/mapbox-gl-js/plugins/mapbox-gl-draw/v1.2.0/mapbox-gl-draw.css\' type=\'text/css\' /><!-- Dependencias Animação --><script src=\"https://api.tiles.mapbox.com/mapbox.js/plugins/turf/v2.0.0/turf.min.js\" charset=\"utf-8\"></script><!-- Dependencia Calcular Distância --><script src=\"https://npmcdn.com/@turf/turf@5.1.6/turf.min.js\"></script><!-- Dependencia Roteirizador --><script src=\"https://api.mapbox.com/mapbox-gl-js/plugins/mapbox-gl-directions/v4.0.2/mapbox-gl-directions.js\"></script><link rel=\"stylesheet\" href=\"https://api.mapbox.com/mapbox-gl-js/plugins/mapbox-gl-directions/v4.0.2/mapbox-gl-directions.css\" type=\"text/css\"/><!-- Dependencia Circulos MapBox GL --><script src=\'https://npmcdn.com/mapbox-gl-circle/dist/mapbox-gl-circle.min.js\'></script><!-- Dependencia para simplificar LineStrings (Rotas) --><script>!function(t){if(\"object\"==typeof exports&&\"undefined\"!=typeof module)module.exports=t();else if(\"function\"==typeof define&&define.amd)define([],t);else{(\"undefined\"!=typeof window?window:\"undefined\"!=typeof global?global:\"undefined\"!=typeof self?self:this).cheapRuler=t()}}(function(){return function t(n,e,r){function i(u,f){if(!e[u]){if(!n[u]){var a=\"function\"==typeof require&&require;if(!f&&a)return a(u,!0);if(o)return o(u,!0);var s=new Error(\"Cannot find module \'\"+u+\"\'\");throw s.code=\"MODULE_NOT_FOUND\",s}var h=e[u]={exports:{}};n[u][0].call(h.exports,function(t){var e=n[u][1][t];return i(e||t)},h,h.exports,t,n,e,r)}return e[u].exports}for(var o=\"function\"==typeof require&&require,u=0;u<r.length;u++)i(r[u]);return i}({1:[function(t,n,e){\"use strict\";function r(t,n){return new i(t,n)}function i(t,n){if(void 0===t)throw new Error(\"No latitude given.\");if(n&&!f[n])throw new Error(\"Unknown unit \"+n+\". Use one of: \"+Object.keys(f).join(\", \"));var e=n?f[n]:1,r=Math.cos(t*Math.PI/180),i=2*r*r-1,o=2*r*i-r,u=2*r*o-i,a=2*r*u-o;this.kx=e*(111.41513*r-.09455*o+12e-5*a),this.ky=e*(111.13209-.56605*i+.0012*u)}function o(t,n){return t[0]===n[0]&&t[1]===n[1]}function u(t,n,e){var r=n[0]-t[0],i=n[1]-t[1];return[t[0]+r*e,t[1]+i*e]}n.exports=r,n.exports.default=r;var f=r.units={kilometers:1,miles:1e3/1609.344,nauticalmiles:1e3/1852,meters:1e3,metres:1e3,yards:1e3/.9144,feet:1e3/.3048,inches:1e3/.0254};r.fromTile=function(t,n,e){var r=Math.PI*(1-2*(t+.5)/Math.pow(2,n));return new i(180*Math.atan(.5*(Math.exp(r)-Math.exp(-r)))/Math.PI,e)},i.prototype={distance:function(t,n){var e=(t[0]-n[0])*this.kx,r=(t[1]-n[1])*this.ky;return Math.sqrt(e*e+r*r)},bearing:function(t,n){var e=(n[0]-t[0])*this.kx,r=(n[1]-t[1])*this.ky;if(!e&&!r)return 0;var i=180*Math.atan2(e,r)/Math.PI;return i>180&&(i-=360),i},destination:function(t,n,e){var r=(90-e)*Math.PI/180;return this.offset(t,Math.cos(r)*n,Math.sin(r)*n)},offset:function(t,n,e){return[t[0]+n/this.kx,t[1]+e/this.ky]},lineDistance:function(t){for(var n=0,e=0;e<t.length-1;e++)n+=this.distance(t[e],t[e+1]);return n},area:function(t){for(var n=0,e=0;e<t.length;e++)for(var r=t[e],i=0,o=r.length,u=o-1;i<o;u=i++)n+=(r[i][0]-r[u][0])*(r[i][1]+r[u][1])*(e?-1:1);return Math.abs(n)/2*this.kx*this.ky},along:function(t,n){var e=0;if(n<=0)return t[0];for(var r=0;r<t.length-1;r++){var i=t[r],o=t[r+1],f=this.distance(i,o);if((e+=f)>n)return u(i,o,(n-(e-f))/f)}return t[t.length-1]},pointOnLine:function(t,n){for(var e,r,i,o,u=1/0,f=0;f<t.length-1;f++){var a=t[f][0],s=t[f][1],h=(t[f+1][0]-a)*this.kx,c=(t[f+1][1]-s)*this.ky;if(0!==h||0!==c){var l=((n[0]-a)*this.kx*h+(n[1]-s)*this.ky*c)/(h*h+c*c);l>1?(a=t[f+1][0],s=t[f+1][1]):l>0&&(a+=h/this.kx*l,s+=c/this.ky*l)}var d=(h=(n[0]-a)*this.kx)*h+(c=(n[1]-s)*this.ky)*c;d<u&&(u=d,e=a,r=s,i=f,o=l)}return{point:[e,r],index:i,t:Math.max(0,Math.min(1,o))}},lineSlice:function(t,n,e){var r=this.pointOnLine(e,t),i=this.pointOnLine(e,n);if(r.index>i.index||r.index===i.index&&r.t>i.t){var u=r;r=i,i=u}var f=[r.point],a=r.index+1,s=i.index;!o(e[a],f[0])&&a<=s&&f.push(e[a]);for(var h=a+1;h<=s;h++)f.push(e[h]);return o(e[s],i.point)||f.push(i.point),f},lineSliceAlong:function(t,n,e){for(var r=0,i=[],o=0;o<e.length-1;o++){var f=e[o],a=e[o+1],s=this.distance(f,a);if((r+=s)>t&&0===i.length&&i.push(u(f,a,(t-(r-s))/s)),r>=n)return i.push(u(f,a,(n-(r-s))/s)),i;r>t&&i.push(a)}return i},bufferPoint:function(t,n){var e=n/this.ky,r=n/this.kx;return[t[0]-r,t[1]-e,t[0]+r,t[1]+e]},bufferBBox:function(t,n){var e=n/this.ky,r=n/this.kx;return[t[0]-r,t[1]-e,t[2]+r,t[3]+e]},insideBBox:function(t,n){return t[0]>=n[0]&&t[0]<=n[2]&&t[1]>=n[1]&&t[1]<=n[3]}}},{}]},{},[1])(1)});/* (c) 2017, Mapbox Based on simplify-js (c) 2017, Vladimir Agafonkin Simplify.js, a high-performance JS polyline simplification library mourner.github.io/simplify-js*/\'use strict\';const rulerCache = {};function getRuler(latitude) {// Cache rulers every 0.00001 degrees of latitude    const roundedLatitude = Math.round(latitude * 100000);    if (rulerCache[roundedLatitude] === undefined) {        rulerCache[roundedLatitude] = cheapRuler(latitude, \'meters\');    }    return rulerCache[roundedLatitude];}// Distance between two points in metresfunction getDist(p1, p2) {    getRuler(p1[1]).distance(p1, p2);}// Distance from a point to a segment (line between two points) in metresfunction getSegDist(p, p1, p2) {    const ruler = getRuler(p[1]);    const pointOnLine = ruler.pointOnLine([p1, p2], p).point;    return ruler.distance(p, pointOnLine);}function simplifyDPStep(points, first, last, offsetTolerance, gapTolerance, simplified) {    let maxDistanceFound = offsetTolerance,        index;    for (let i = first + 1; i < last; i++) {        const distance = getSegDist(points[i], points[first], points[last]);        if (distance > maxDistanceFound) {            index = i;            maxDistanceFound = distance;        }    }    // Don\'t remove a point if it would create a segment longer    // than gapTolerance    const firstLastDist = getDist(points[first], points[last]);    if (maxDistanceFound > offsetTolerance || firstLastDist > gapTolerance) {        if (index - first > 1) simplifyDPStep(points, first, index, offsetTolerance, gapTolerance, simplified);        simplified.push(points[index]);        if (last - index > 1) simplifyDPStep(points, index, last, offsetTolerance, gapTolerance, simplified);    }}// simplification using Ramer-Douglas-Peucker algorithmfunction simplifyDouglasPeucker(points, offsetTolerance, gapTolerance) {    const last = points.length - 1;    const simplified = [points[0]];    simplifyDPStep(points, 0, last, offsetTolerance, gapTolerance, simplified);    simplified.push(points[last]);    return simplified;}function simplify(points, offsetTolerance, gapTolerance) {    if (points.length <= 2) return points;    points = simplifyDouglasPeucker(points, offsetTolerance, gapTolerance);    return points;}</script><!-- Classe dos controles Top-left--><style>.mapboxgl-ctrl-top-left {    top: 40px;    left: 0;}</style><!-- Classe dos controles Top-Right--><style>.mapboxgl-ctrl-top-right {    top: 40px;    right: 0;}</style><!-- Classe botão close geocoder --><style>.geocoder-icon-close {    background-image: url(data:image/svg+xml;base64,PHN2ZyB4bWxuczpzdmc9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCAyMCAyMCIgdmVyc2lvbj0iMS4xIiBoZWlnaHQ9IjIwIiB3aWR0aD0iMjAiPg0KICA8cGF0aCBkPSJtNSA1IDAgMS41IDMuNSAzLjUtMy41IDMuNSAwIDEuNSAxLjUgMCAzLjUtMy41IDMuNSAzLjUgMS41IDAgMC0xLjUtMy41LTMuNSAzLjUtMy41IDAtMS41LTEuNSAwLTMuNSAzLjUtMy41LTMuNS0xLjUgMHoiIGZpbGw9IiMwMDAiLz4NCjwvc3ZnPg==);    visibility: hidden;}</style><!-- Classe do Scroll do MenuLateral --><style>#MenuMapaLateralDireita::-webkit-scrollbar-track{	border-radius: 10px;}#MenuMapaLateralDireita::-webkit-scrollbar{	width: 6px;	background-color: #F5F5F5;}#MenuMapaLateralDireita::-webkit-scrollbar-thumb{	border-radius: 10px;	-webkit-box-shadow: inset 0 0 6px rgba(0,0,0,.3);	background-color: background: rgba(51, 51, 51,0.2);}</style><!-- Classe do popup--><style>.popupMapBoxRastreamento {	width: 325px;	max-width: 325px !important;}.mapboxgl-popup-content {   	position: relative;    	background: #fff;    	border-radius: 12px;    	box-shadow: 0 1px 2px rgba(0,0,0,.1);    	padding: 10px 10px 15px;    	pointer-events: auto;	box-shadow: 0 3px 14px rgba(0,0,0,0.4);}.mapboxgl-popup-close-button {    position: absolute;    right: 2px;    top: 1px;    border: 0;    border-radius: 0 3px 0 0;    cursor: pointer;    background-color: transparent;    font-size: 20px;}</style><!-- Classes da função de calcular distância--><style>.distance-container {position: absolute;top: 7px;left: 395px;z-index: 1;} .distance-container > * {background-color: rgba(0, 0, 0, 0.5);color: #fff;font-size: 11px;line-height: 18px;display: block;margin: 0;padding: 5px 10px;border-radius: 3px;}</style><!-- Classes do popup de adicionar nome ao polígono--><style>/* The Modal (background) */.modalMap {  display: none; /* Hidden by default */  position: fixed; /* Stay in place */  z-index: 9999; /* Sit on top */  padding-top: 20%; /* Location of the box */  padding-left: 40%;  padding-right: 40%;  left: 0;  top: 0;  width: 100%; /* Full width */  height: 100%; /* Full height */  overflow: auto; /* Enable scroll if needed */  background-color: rgb(0,0,0); /* Fallback color */  background-color: rgba(0,0,0,0.4); /* Black w/ opacity */}/* Modal Content */.modalMap-content {  background-color: #fefefe;  margin: auto;  padding: 20px;  border: 1px solid #888;  width: 250px;}/* The Close Button */.closeMap {  color: #aaaaaa;  float: right;  font-size: 28px;  font-weight: bold;}.closeMap:hover,.closeMap:focus {  color: #000;  text-decoration: none;  cursor: pointer;}</style><!-- Classes para toast message ao salvar os itens do mapa--><style>#snackbar {  visibility: hidden;  min-width: 250px;  margin-left: -125px;  background-color: #005baa;  color: #fff;  font-weight: 800;  text-align: center;  border-radius: 2px;  padding: 16px;  position: fixed;  z-index: 1;  left: 50%;  bottom: 50px;  font-size: 17px;}#snackbar.show {  visibility: visible;  -webkit-animation: fadein 0.5s, fadeout 0.5s 2.5s;  animation: fadein 0.5s, fadeout 0.5s 2.5s;}@-webkit-keyframes fadein {  from {bottom: 0; opacity: 0;}   to {bottom: 30px; opacity: 1;}}@keyframes fadein {  from {bottom: 0; opacity: 0;}  to {bottom: 30px; opacity: 1;}}@-webkit-keyframes fadeout {  from {bottom: 30px; opacity: 1;}   to {bottom: 0; opacity: 0;}}@keyframes fadeout {  from {bottom: 30px; opacity: 1;}  to {bottom: 0; opacity: 0;}}</style><!-- Classes para menu no mapa--><style>.sidenav {  /*top: -60px;*/  background-color: #ffffff;  overflow-x: hidden;  transition: 0.5s;  margin-left:auto;  right:0;  padding-top:60px;  float:right;}.sidenav a {  padding: 8px 8px 8px 32px;  text-decoration: none;  font-size: 25px;  color: #818181;  display: block;  transition: 0.3s;}.sidenav a:hover {  color: #000;}.sidenav .closebtn {  position: absolute;  top: 10px;  right: 25px;  font-size: 36px;  margin-left: 50px;} #mainHoverMenu {    transition: margin-left .5s;    padding: 16px;    margin-right: 5px;    position: relative;    border-radius: 50%;    -moz-border-radius: 50%;    -webkit-border-radius: 50%;    z-index: 999;    float: right;}@media screen and (max-height: 450px) {  .sidenav {padding-top: 15px;}  .sidenav a {font-size: 18px;}}</style><!-- Div onde irá ficar o mapa --><div id=\'map\' style=\'width: {{Width}}; height: {{Height}};\'></div><!-- Div com o menu lateral no mapa --><div id=\"mySidenav\" class=\"sidenav\" style=\"position: absolute;z-index: 1001;margin-right: auto; height: 100%;padding-bottom: 10px; left: auto;box-shadow: rgba(0, 0, 0, 0.65) 0px 1px 5px;\">  <a href=\"javascript:void(0)\" class=\"closebtn\" onclick=\"mythisMapBoxGL._openCloseMenuMapa()\">&times;</a> <!-- Ao clicar fecha o menu --></div><!-- Div Modal nome polígono --><div id=\"myModal\" class=\"modalMap\">  <div class=\"modalMap-content\">	<p style=\"font-weight: 800;height: 20px;\">Informe o nome do polígono</p>	<input type=\"text\" Id=\"InputPoligono\" name=\"NomePoligono\" placeholder=\"Entre com o nome do polígono...\" style=\" width: 100%;border-color: black;border-width: 1px;margin: 0;\"><br>	<p Id=\"MensagemErroNomePoligono\" style=\"font-weight: 400;color: red;visibility: hidden;font-size: 10px;\">Já existe um poligono com este nome.</p>	<div style=\"position: relative;height: 30px;\">		<div style=\"font-weight: 900;background-color: white;border-color: lightgray;border-width: 0.5px;height: 30px;width: 80px;margin-top: 10px;border: 1px solid lightgray;text-align: center;padding-top: 5px;cursor: pointer;position: relative;float: left;margin-left: 20px;background: #005baa;color: white;\" onclick=\"mythisMapBoxGL._VerificaErrosNomePoligono()\">Salvar</div>		<div style=\"font-weight: 900;background-color: white;border-color: lightgray;border-width: 0.5px;height: 30px;width: 80px;margin-top: 10px;border: 1px solid lightgray;text-align: center;padding-top: 5px;cursor: pointer;float: right;position: relative;margin-right: 20px;\" onclick=\"mythisMapBoxGL._CancelaInsercaoPoligono()\">Cancelar</div>	</div>  	<!-- <div style=\"font-weight: 900;background-color: white;border-color: lightgray;border-width: 0.5px;height: 30px;width: 80px;margin-top: 10px;border: 1px solid lightgray;text-align: center;padding-top: 5px;cursor: pointer;\" onclick=\"mythisMapBoxGL._VerificaErrosNomePoligono()\">Salvar</div>  	-->  </div></div><!-- Div Modal nome e largura rota --><!--<div id=\"myModalRota\" class=\"modalMap\">  <div class=\"modalMap-content\">		<p style=\"font-weight: 800;height: 20px;\">Informe o nome da rota</p>	<input type=\"text\" Id=\"InputRota\" name=\"NomeRota\" placeholder=\"Entre com o nome da rota...\" style=\" width: 100%;border-color: black;border-width: 1px;\"><br>	<p Id=\"MensagemErroNomeRota\" style=\"font-weight: 400;color: red;visibility: hidden;font-size: 10px;\">Já existe uma rota com este nome.</p>   	<p style=\"font-weight: 800;height: 20px;\">Informe a largura da rota</p>	<input type=\"number\" Id=\"InputLarguraRota\" name=\"LarguraRota\" placeholder=\"Entre com a largura da rota...\" style=\" width: 100%;border-color: black;border-width: 1px;\"><br>	<p Id=\"MensagemLarguraRota\" style=\"font-weight: 400;color: red;visibility: hidden;font-size: 10px;\">Informe a largura da rota.</p>	<div style=\"font-weight: 900;background-color: white;border-color: lightgray;border-width: 0.5px;height: 30px;width: 80px;margin-top: 10px;border: 1px solid lightgray;text-align: center;padding-top: 5px;cursor: pointer;\" onclick=\"mythisMapBoxGL._VerificaErrosNomeRota()\">Salvar</div>	  </div></div>--><!-- Div Modal nome do circulo --><div id=\"myModalCirculo\" class=\"modalMap\"> <div class=\"modalMap-content\">	<p style=\"font-weight: 800;height: 20px;\">Informe o nome do círculo</p>	<input type=\"text\" Id=\"InputNomeCirculo\" name=\"NomeCirculo\" placeholder=\"Entre com o nome do círculo...\" style=\" width: 100%;border-color: black;border-width: 1px;margin: 0;\"><br>	<p Id=\"MensagemErroNomeCirculo\" style=\"font-weight: 400;color: red;visibility: hidden;font-size: 10px;\">Já existe um círculo com este nome.</p>	<div style=\"position: relative;height: 30px;\">		<div style=\"font-weight: 900;background-color: white;border-color: lightgray;border-width: 0.5px;height: 30px;width: 80px;margin-top: 10px;border: 1px solid lightgray;text-align: center;padding-top: 5px;cursor: pointer;position: relative;float: left;margin-left: 20px;background: #005baa;color: white;\" onclick=\"mythisMapBoxGL._VerificaErrosNomeCirculo()\">Salvar</div>		<div style=\"font-weight: 900;background-color: white;border-color: lightgray;border-width: 0.5px;height: 30px;width: 80px;margin-top: 10px;border: 1px solid lightgray;text-align: center;padding-top: 5px;cursor: pointer;float: right;position: relative;margin-right: 20px;\" onclick=\"mythisMapBoxGL._CancelaInsercaoCirculo()\">Cancelar</div>	</div>    </div></div><!-- Div com o controle de Menu no Mapa --><div id=\"GrupoMenuMapa\" class=\"mapboxgl-ctrl mapboxgl-ctrl-group\">	<button id=\"btnMenuMapa\" class=\"\" type=\"button\" title=\"Menu\" aria-label=\"Zoom in\" onclick=\"mythisMapBoxGL._openCloseMenuMapa()\">		<i class=\"fas fa-bars\" style=\"font-size: 15px;color: black;\"></i>	</button></div><!-- Div com o controle de percurso --><div id=\"GrupoControle\" class=\"mapboxgl-ctrl mapboxgl-ctrl-group\"><button Id=\"btnPercurso\" class=\"\" type=\"button\" title=\"Percurso\" aria-label=\"Zoom in\" onclick=\"openCloseNav()\"><i class=\"fas fa-route\" style=\"font-size: 15px;\"></i></button><button Id=\"btnDistancia\" class=\"\" type=\"button\" title=\"Distância\" aria-label=\"Zoom in\" onclick=\"mythisMapBoxGL._CalculaDistancia()\"><i class=\"fas fa-ruler\" style=\"font-size: 15px;\"></i></button><button Id=\"btnRota\" class=\"\" type=\"button\" title=\"Roteirizador\" aria-label=\"Zoom in\" onclick=\"mythisMapBoxGL._openCloseControleRotas()\"><i class=\"fas fa-directions\" style=\"font-size: 15px;\"></i></button></div><!-- Botão de salvar desenhos do mapa --><button Id=\"btnSaveDrawMap\" class=\"\" type=\"button\" title=\"Salvar\" aria-label=\"Zoom in\" onclick=\"mythisMapBoxGL.salvaDesenhosMapa()\"><i class=\"fas fa-save\" style=\"font-size: 15px;color: black;\"></i></button><!-- Botão de remover desenhos do mapa --><button Id=\"btnRemoveDrawMap\" class=\"\" type=\"button\" title=\"Remover\" aria-label=\"Zoom in\" onclick=\"mythisMapBoxGL._removeDesenhosMapa()\"><i class=\"fas fa-trash-alt\" style=\"font-size: 15px;color: black;\"></i></button><!-- Botão de sair da tela --><button id=\"btnBack\" class=\"\" type=\"button\" title=\"Sair\" aria-label=\"Zoom in\" onclick=\"mythisMapBoxGL.Sair()\"><i class=\"fas fa-sign-out-alt\" style=\"font-size: 15px;color: black;\" aria-hidden=\"true\"></i></button><!-- Botão de desenhar circulo no mapa --><button id=\"BtnDrawCircle\" type=\"button\" class=\"mapbox-gl-draw_ctrl-draw-btn fal fa-draw-circle\" title=\"Círculo\" style=\"font-weight: 800;font-size: 15px;color: black;\" onclick=\"mythisMapBoxGL._AdicionaCirculoMapa()\"></button><!-- Div com a lupa de busca --><div id=\"DivBusca\" style=\"height: 100%;width: 30px;position: absolute;cursor: pointer;\"><i class=\"fas fa-search\" style=\"cursor: pointer;font-size: 15px;top: 8px;left: 7.5px;width: 20px;height: 20px;position: absolute;\"></i></div><!-- Div com a função de calcular distância --><div id=\"distance\" class=\"distance-container\"></div><!-- Div com a toast message ao salvar o mapa --><div id=\"snackbar\">Salvo com sucesso.</div><script>var marker = [];var htmlMarker = [];var htmlMarkerRota = [];var markerRota = [];var pontosRemovidos = [];var CalcularDistanciaEmUso = \'false\';var ControleRotasEmUso = \'false\';var CircleResultGeocoder = [];var ControleCirculosEmUso = \'false\';var idCirculo = 0;var NomeRotaAdicionada;var LarguraRotaAdicionada;//var CarregamentoGeoJson = false;var idPoligonoCriado;var PoligonoCriado;var ListaNomePoligonos;var controleRoteirizador;var GeocoderCircle;var idCirculoSelecionado;var teste;var TabAtivaMenuMapa = \'\';var MenuOpen = false;</script>';
	Mustache.parse(template);
	var _iOnPontoRemovidoMapa = 0; 
	var _iOnDesenhosSalvosMapa = 0; 
	var _iOnPontosRotaOtimizados = 0; 
	var _iOnSair = 0; 
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts
			this.killmustache(); 

			_iOnPontoRemovidoMapa = 0; 
			_iOnDesenhosSalvosMapa = 0; 
			_iOnPontosRotaOtimizados = 0; 
			_iOnSair = 0; 

			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this));
			this.renderChildContainers();

			$(this.getContainerControl())
				.find("[data-event='PontoRemovidoMapa']")
				.on('pontoremovidomapa', this.onPontoRemovidoMapaHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 
			$(this.getContainerControl())
				.find("[data-event='DesenhosSalvosMapa']")
				.on('desenhossalvosmapa', this.onDesenhosSalvosMapaHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 
			$(this.getContainerControl())
				.find("[data-event='PontosRotaOtimizados']")
				.on('pontosrotaotimizados', this.onPontosRotaOtimizadosHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 
			$(this.getContainerControl())
				.find("[data-event='Sair']")
				.on('sair', this.onSairHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			// Raise after show scripts
			this.ShowMap(); 
	}

	this.Scripts = [];

		this.ShowMap = function() {

				
			    if (!mythisMapBoxGL.IsPostBack){ 
			          
			      this.setHtml = function(b){      
				        if (!mythisMapBoxGL.IsPostBack){ 
					          gx.dom.shouldPurge() && gx.dom.purge(mythisMapBoxGL.getContainerControl(), !0);
					          mythisMapBoxGL.getContainerControl().innerHTML = b      
				      	    
					  }
			      } 
				
				mapboxgl.accessToken = mythisMapBoxGL.MapKey;
				map = new mapboxgl.Map({
					container: 'map',
					style: 'mapbox://styles/mapbox/streets-v11', 
					center: [parseFloat(mythisMapBoxGL.LongitudeInicial) , parseFloat(mythisMapBoxGL.LatitudeInicial)], 
					zoom: mythisMapBoxGL.ZoomInicial 
				});
				
				//Adiciona o canvas do mapa como relativo (Fix para adicionar pontos clicando na tela (funções direção, roteirizador, etc))
				document.getElementsByClassName('mapboxgl-canvas')[0].style.position = 'relative';
				
				//Adiciona o Menu no mapa
				if(mythisMapBoxGL.UtilizarMenuMapa === 'Sim'){
					
					$("#" + mythisMapBoxGL.TableMenuInternalName).prependTo("#mySidenav");
					$("#GrupoMenuMapa").appendTo(document.getElementsByClassName('mapboxgl-ctrl-top-right')[0]);
					
					document.getElementById("mySidenav").style.width = "0px";
					$("#mySidenav").prependTo("#map");
					
				}else{
					
					document.getElementById('GrupoMenuMapa').remove();
					
				}
				
				// Adiciona o controle de busca ao mapa caso tenha setado a propriedade como Sim
				if(mythisMapBoxGL.UtilizarControleDeBusca === 'Sim'){
					map.addControl(
					new MapboxGeocoder({
						accessToken: mythisMapBoxGL.MapKey,
						mapboxgl: mapboxgl,
						placeholder: 'Pesquise no mapa',
						language: 'pt-BR',
						countries: 'br'
					})
					,'top-left');
					
					document.getElementsByClassName('mapboxgl-ctrl-geocoder--icon mapboxgl-ctrl-geocoder--icon-search')[0].remove(); //Remove o icone da lupa
					$(document.getElementById('DivBusca')).prependTo(document.getElementsByClassName('mapboxgl-ctrl-geocoder mapboxgl-ctrl')[0]); //Adiciona o novo icone de lupa
					
					//Adicionando as classes
					document.getElementsByClassName('mapboxgl-ctrl-geocoder mapboxgl-ctrl')[0].style.fontSize = '18px';
					document.getElementsByClassName('mapboxgl-ctrl-geocoder mapboxgl-ctrl')[0].style.lineHeight = '24px';
					document.getElementsByClassName('mapboxgl-ctrl-geocoder mapboxgl-ctrl')[0].style.fontFamily = '"Open Sans", "Helvetica Neue", Arial, Helvetica, sans-serif';
					document.getElementsByClassName('mapboxgl-ctrl-geocoder mapboxgl-ctrl')[0].style.position = 'relative';
					document.getElementsByClassName('mapboxgl-ctrl-geocoder mapboxgl-ctrl')[0].style.backgroundColor = '#fff';
					document.getElementsByClassName('mapboxgl-ctrl-geocoder mapboxgl-ctrl')[0].style.minWidth = '30px';
					document.getElementsByClassName('mapboxgl-ctrl-geocoder mapboxgl-ctrl')[0].style.zIndex= '1';
					document.getElementsByClassName('mapboxgl-ctrl-geocoder mapboxgl-ctrl')[0].style.borderRadius = '4px';
					document.getElementsByClassName('mapboxgl-ctrl-geocoder mapboxgl-ctrl')[0].style.transition = 'width .25s, min-width .25s';
					document.getElementsByClassName('mapboxgl-ctrl-geocoder mapboxgl-ctrl')[0].style.Width = '30px';
					document.getElementsByClassName('mapboxgl-ctrl-geocoder mapboxgl-ctrl')[0].style.height = '33px';
					document.getElementsByClassName('mapboxgl-ctrl-geocoder mapboxgl-ctrl')[0].style.boxShadow = '0 0 0 2px rgba(0,0,0,.1)';
					
					
					document.getElementsByClassName('mapboxgl-ctrl-geocoder--input')[0].style.position = 'relative';
					document.getElementsByClassName('mapboxgl-ctrl-geocoder--input')[0].style.left = '21px';
					document.getElementsByClassName('mapboxgl-ctrl-geocoder--input')[0].style.width = '190px';
					document.getElementsByClassName('mapboxgl-ctrl-geocoder--input')[0].style.height = '33px';
					document.getElementsByClassName('mapboxgl-ctrl-geocoder--input')[0].style.visibility = 'hidden'; //'visible'
					
					//Adiciona o evento de click na lupa para expandir ou esconder a barra de busca
					document.getElementById('DivBusca').addEventListener("click", function(){if(document.getElementsByClassName('mapboxgl-ctrl-geocoder mapboxgl-ctrl')[0].style.width === '30px')
						{document.getElementsByClassName('mapboxgl-ctrl-geocoder mapboxgl-ctrl')[0].style.width = '240px';
							document.getElementsByClassName('mapboxgl-ctrl-geocoder--input')[0].style.visibility = 'visible';}
						else{document.getElementsByClassName('mapboxgl-ctrl-geocoder mapboxgl-ctrl')[0].style.width = '30px';
							document.getElementsByClassName('mapboxgl-ctrl-geocoder--input')[0].style.visibility = 'hidden';}}, false);
					
				}else{
					document.getElementById('DivBusca').remove();
				}
				
				// Adiciona o controle de zoom no mapa
				map.addControl(new mapboxgl.NavigationControl({showCompass: false}),'top-left');
				
				// Adiciona o grupo de controles com trajetos, senão remove o botão
				if(mythisMapBoxGL.UtilizarControleTrajeto === 'Sim'){
					$("#MENUHOVERContainer").prependTo("#map");
				}else{
					document.getElementById('btnPercurso').remove();
				}
				
				// Remove do grupo de controles a função de distância caso não tenha selecionado para utilizar
				if(mythisMapBoxGL.UtilizarControleDistancia === 'Nao'){
					document.getElementById('btnDistancia').remove();
				}
				
				// Remove do grupo de controles o botão de rotas caso não tenha selecionado para utilizar
				if(mythisMapBoxGL.UtilizarControleRota === 'Nao'){
					document.getElementById('btnRota').remove();
				}
				
				//Caso não utilize nehum controle custom, irá remover a div de controles custom do mapa
				if(mythisMapBoxGL.UtilizarControleTrajeto === 'Nao' && mythisMapBoxGL.UtilizarControleDistancia === 'Nao' && mythisMapBoxGL.UtilizarControleRota === 'Nao'){
					document.getElementById('GrupoControle').remove();	
				}else{
					$("#GrupoControle").appendTo(document.getElementsByClassName('mapboxgl-ctrl-top-left')[0]);
				}
				
				// Adiciona o botão de FullScreen no mapa
				map.addControl(new mapboxgl.FullscreenControl(),'top-left');
				
				// Adiciona o controle de desenho ao mapa caso tenha setado a propriedade como Sim
				if(mythisMapBoxGL.AdicionarControleDeDesenho === 'Sim'){
					
					draw = new MapboxDraw({
						displayControlsDefault: false,
						//userProperties: true,
						controls: {
							//point: true,
							polygon: true,
							//line_string: true,
							//trash: true
						}
					});
					
					map.addControl(draw, 'top-left');
					
					//Adiciona o botão de salvar ao grupo de botões de desenho
					$("#btnSaveDrawMap").appendTo(document.getElementsByClassName('mapboxgl-ctrl-group mapboxgl-ctrl')[document.getElementsByClassName('mapboxgl-ctrl-group mapboxgl-ctrl').length-1]);
					
					//Adiciona o botão de remover ao grupo de botões de desenho
					$("#btnRemoveDrawMap").appendTo(document.getElementsByClassName('mapboxgl-ctrl-group mapboxgl-ctrl')[document.getElementsByClassName('mapboxgl-ctrl-group mapboxgl-ctrl').length-1]);
					
					//Adiciona o botão de sair ao grupo de botões de desenho
					$("#btnBack").appendTo(document.getElementsByClassName('mapboxgl-ctrl-group mapboxgl-ctrl')[document.getElementsByClassName('mapboxgl-ctrl-group mapboxgl-ctrl').length-1]);
					
					//Adiciona o botão de desenhar círculo ao grupo de botões de desenho
					$("#BtnDrawCircle").prependTo(document.getElementsByClassName('mapboxgl-ctrl-group mapboxgl-ctrl')[document.getElementsByClassName('mapboxgl-ctrl-group mapboxgl-ctrl').length-1]);
					
					
					map.on('draw.create', EnviaDadosAtualizadosMapaCreate);
					
					function EnviaDadosAtualizadosMapaCreate(e) { //Esta função envia um evento para a tela no momento que o polígono é criado na tela
						
						try {	
							
							//Mostra o modal de adicionar o nome do polígono caso tenha adicionado um poligono na tela
							if(e.features[0].geometry.type === 'Polygon'){
								idPoligonoCriado = '';
								idPoligonoCriado = e.features[0].id;
								var data = draw.getAll();
								dataMapa = JSON.stringify(data); //Adiciona o Geojson na variavel
								document.getElementById("myModal").style.display = 'block' //Mostra o modal de inserir o nome do polígono na tela
							}
							
						}
						catch (e) {
							
							console.log(e);
							
						}
					}
					
				}else{
					document.getElementById('btnRemoveDrawMap').remove(); //Remove o botão de remover desenhos
					document.getElementById('btnSaveDrawMap').remove(); //Remove o botão de salvar desenhos
					document.getElementById('BtnDrawCircle').remove(); //Remove o botão de senhar circulos do mapa
					document.getElementById('btnBack').remove(); //Remove o botão de sair do mapa
				}
				
				
				// Adiciona a ferramenta de filtro (Placa, Id do módulo e CPF/CNPJ) ao mapa caso tenha setado a propriedade como Sim
				if(mythisMapBoxGL.UtilizarFerramentaDeFiltro === 'Sim'){
					
					mythisMapBoxGL._AdicionaTableBuscaNoMapa(); //Chama a função que movimenta a table de filtro para o mapa
					
				}
				
				//Alterando as cores dos desenhos	
			//	if(mythisMapBoxGL.AdicionarControleDeDesenho === 'Sim'){
			//		try {
			//			
			//			setTimeout(function(){  
			//				map.setPaintProperty('gl-draw-polygon-stroke-inactive.cold', 'line-color', '#005baa'); //Altera a cor da borda do poligono quando ele não está selecionado
			//				map.setPaintProperty('gl-draw-polygon-stroke-active.cold', 'line-color', '#005baa'); //Altera a cor da borda do poligono quando ele está selecionado
			//				map.setPaintProperty('gl-draw-line-inactive.cold', 'line-color', '#005baa'); //Altera a cor da linha do polyline quando ele não está selecionado
			//				map.setPaintProperty('gl-draw-line-inactive.cold', 'line-width', 5); //Seta a largura da linha do polyline quando ele não está ativo
			//			}, 2000); //aguarda 2 segundos para renderizar o mapa na tela
			//		
			//		}catch (e) {
			//			
			//		  	setTimeout(function(){  
			//				map.setPaintProperty('gl-draw-polygon-stroke-inactive.cold', 'line-color', '#005baa'); //Altera a cor da borda do poligono quando ele não está selecionado
			//				map.setPaintProperty('gl-draw-polygon-stroke-active.cold', 'line-color', '#005baa'); //Altera a cor da borda do poligono quando ele está selecionado
			//				map.setPaintProperty('gl-draw-line-inactive.cold', 'line-color', '#005baa'); //Altera a cor da linha do polyline quando ele não está selecionado
			//				map.setPaintProperty('gl-draw-line-inactive.cold', 'line-width', 5); //Seta a largura da linha do polyline quando ele não está ativo
			//			}, 3000); //aguarda 3 segundos para renderizar o mapa na tela
			//		   
			//		}
			//	}

			      this.mustache = Mustache;	
				
			    }


		}
		this.killmustache = function() {

			   
			    //Variáveis Globais
			    mythisMapBoxGL = this;
			    
			    if (!mythisMapBoxGL.IsPostBack){ 
			          
			      this.setHtml = function(b){      
				        if (!mythisMapBoxGL.IsPostBack){ 
					          gx.dom.shouldPurge() && gx.dom.purge(mythisMapBoxGL.getContainerControl(), !0);
					          mythisMapBoxGL.getContainerControl().innerHTML = b      
				        }
			      } 
				
			      this.mustache = Mustache;
				
				 //Variáveis Globais
				var map;
				var dataMapa;
				var draw;
				
			    }

			 
		}
		this.salvaDesenhosMapa = function() {

			 	
				try {
				      
					//Busca as rotas criadas e salva no parâmetro de consulta
					if(map.getSource('directions') != undefined){
						
						for(i = 0; i < map.getSource('directions')._data.features.length; i++){
							if(map.getSource('directions')._data.features[i].properties.route === 'selected'){
								
								var dataRota = map.getSource('directions')._data.features[i];
								
								//Adicionando o nome e a largura
								dataRota.properties.name = NomeRotaAdicionada
								dataRota.properties.width = LarguraRotaAdicionada
								
								mythisMapBoxGL.GeojsonRetorno_Rota = JSON.stringify(dataRota);
								break; //sai do for
							}
						}
						
					}
					
					//Busca os desenhos da Draw API e salva no parâmetro de consulta
					var data = draw.getAll();
					dataMapa = JSON.stringify(data);
					mythisMapBoxGL.GeojsonRetorno_DrawAPI = dataMapa;
					
					//Busca os circulos do mapa e salva no parâmetro de consulta
					var geojsonCircleCollection = [];
					for(i = 0; i < CircleResultGeocoder.length; i++){
						
						if(CircleResultGeocoder[i] != undefined){
							
							var circleGeoJson = CircleResultGeocoder[i]._getCircleGeoJSON()
							circleGeoJson.features[0].geometry.type = 'circle';
							circleGeoJson.features[0].geometry.coordinates = CircleResultGeocoder[i].center
							circleGeoJson.features[0].properties.radius = CircleResultGeocoder[i].getRadius()
							
							geojsonCircleCollection.push(circleGeoJson);
							
						}
						
					}
					mythisMapBoxGL.GeojsonRetorno_Circulos = JSON.stringify(geojsonCircleCollection);
					
					//Ativa o evento no WebPanel para avisar que foi salvo os desenhos do mapa
					mythisMapBoxGL.DesenhosSalvosMapa() 
					
					//Mostra a mensagem de sucesso ao salvar
					mythisMapBoxGL._ShowToast()
					
				}
				catch (e) {
					
				   console.log(e);
				   
				}
				
			 	
				
			 
		}
		this.Resize = function() {

			      
				try {
					
					map.resize();
				     	
				}
				catch (e) {
					
				   console.log(e);
				   
				}
				

		}
		this.AdicionaGeoJson = function(GeoJson ,GeoJsonCirculos ) {

			      
				try {
					
				      draw.deleteAll(); //Deleta todos os objetos do mapa
				      var ObjGeoJson = JSON.parse(GeoJson); //Transforma o GeoJson em um objeto
				      draw.add(ObjGeoJson); //Adiciona o GeoJson no Mapa
					
					if(GeoJsonCirculos != ''){
						
						var ObjGeoJsonCirculos = JSON.parse(GeoJsonCirculos); //Transforma o GeoJson em um objeto
						
						CircleResultGeocoder = [];
						
						//Carrega os circulos na tela
						for(i = 0; i < ObjGeoJsonCirculos.length; i++){
							
							//Adiciona o círculo ao mapa
							CircleResultGeocoder.push(new MapboxCircle({lat: ObjGeoJsonCirculos[i].features[0].geometry.coordinates[1], lng: ObjGeoJsonCirculos[i].features[0].geometry.coordinates[0]}, ObjGeoJsonCirculos[i].features[0].properties.radius, {
								editable: true,
								fillColor: '#005baa',
								strokeColor: '#005baa',
								strokeWeight: 2,
								properties: {id: ObjGeoJsonCirculos[i].features[0].properties.id,name: ObjGeoJsonCirculos[i].features[0].properties.name}
							}).addTo(map));
							
							CircleResultGeocoder[CircleResultGeocoder.length-1].on('click', function (e) {
								
								//Ao clicar é feita uma verificação para encontrar em qual circulo clicou filtrando se o lat/long do click está dentro do circulo
								
								//Cria um ponto com o lat/lng
								var ponto = turf.point([e.lngLat.lng,e.lngLat.lat]);
								
								//Busca o Id do circulo clicado
								for(i = 0; i < CircleResultGeocoder.length; i++){
									
									if(CircleResultGeocoder[i] != undefined){
										
										//Gera um polígono a partir do circulo
										var CenterCircle = [CircleResultGeocoder[i].getCenter().lng, CircleResultGeocoder[i].getCenter().lat];
										var RadiusCircle = CircleResultGeocoder[i].getRadius();
										var OptionsCircle = {units: 'kilometers'};
										var CircleTurf = turf.circle(CenterCircle, RadiusCircle, OptionsCircle);
										
										//Cria um poligo com os dados do circulo
										var polygon = turf.polygon(CircleTurf.geometry.coordinates)
										
										if(turf.booleanPointInPolygon(ponto, polygon) === true){
											
											//Guarda o Id do círculo clicado
											idCirculoSelecionado = CircleResultGeocoder[i]._circle.properties.id
											
											break; //Encontrou o círculo, sai do for
										}
										
									}
									
								}
								
							});
							
							idCirculo = ObjGeoJsonCirculos[i].features[0].properties.id;
							
						}
						
					}
					
					//CarregamentoGeoJson = true;
					//setTimeout(function(){  
					//	mythisMapBoxGL.salvaDesenhosMapa(); //Manda para tela do usuario o GeoJson Atual.
					//}, 5000); //aguarda 5 segundos para renderizar o mapa na tela
					
					
				}
				catch (e) {
					
				   console.log(e);
				   
				}
			     

		}
		this.adicionaPontosMapa = function(json ,UtilizarZoomAutomatico ) {

			     	
				try {
					
					var array = JSON.parse(json);
					var num;
					var boundsZoom = [];
					
					arrayLen = array.length;
					
					for (i = 0; i < arrayLen; i++) {
						
						var LatlngMarker = [parseFloat(array[i].PontosLongitude) , parseFloat(array[i].PontosLatitude)];
						var num = parseInt(array[i].PontosId);
						
						boundsZoom.push([parseFloat(array[i].PontosLongitude) , parseFloat(array[i].PontosLatitude)]) //Adiciona na variável para dar zoom nos pontos
						
						//Caso já existir um ponto com este Id irá remover o ponto, para criar no novo local (Mover o ponto)
						if(marker[num] != undefined){
							
							htmlMarker[num].remove(); //Remove o html do ponto do mapa
							marker[num].remove(); //Remove o ponto antigo
							marker[num] = undefined; //limpa a varivável do ponto antigo
							
						}
						
						if(array[i].UtilizarConteudoBalaoHTML == true){
							
							var contentString = array[i].ConteudoBalaoHTML;
							
							//Cria o popup para adicionar ao ponto
							var popup = new mapboxgl.Popup({ offset: 5}).setHTML(contentString);
							
						}else{
							
							var URLGoogleMaps = "https://www.google.com/maps/search/?api=1&query=" + array[i].PontosLatitude + "," + array[i].PontosLongitude;
							var URLStreetView = "http://maps.google.com/maps?q=&layer=c&cbll=" + array[i].PontosLatitude + "," + array[i].PontosLongitude;
							
							//Variável com o conteúdo de texto da caixa ao clicar no ponto
							if(array[i].MostrarEnvioComandos == true){
								var contentString = '<div id="content" style="padding: 5px;">'+
								'<p style="font-size: 16px; margin: auto;"><strong>' + array[i].VeiculoPlaca + '</strong></p>';
								
								//Se tiver o nome do motorista, irá adicionar no balão
								if(array[i].Motorista.length > 0){
									contentString += '<p style="font-size: 14px; margin: auto;"><strong>Motorista: </strong>' + array[i].Motorista + '</p>';
								}
								
								contentString += '<p style="font-size: 14px; margin: auto;"><strong>Ignição: </strong>' + array[i].Ignicao + ' / ' + array[i].Velocidade + ' KM/H </p>' +
								'<p style="font-size: 14px; margin: auto;"><strong>Hora GPS: </strong>' + array[i].DataHoraPosicao + '</p>' +
								'<p style="font-size: 14px; margin: auto;"><strong>Endereço: </strong>' + array[i].Endereco + '</p>' +
								'<p style="font-size: 14px; margin: auto;"><strong>Tensão da bateria: </strong>'  + array[i].TensaoBateria + '</p>' +
								'<p style="font-size: 14px; margin: auto;color:red;"><strong>'  + array[i].VeiculoRoubado + '</strong></p>' +
								'<br>' +
								'<table style="height: 40px;margin-top: 10px;margin-left: auto;width: 165px;margin-right: auto;width="266">' +
								'<tbody>' +
								'<tr>' +
								'<th>' + 
								'<a href="' + URLGoogleMaps +'" target="_blank" style="color:black;"><i class="fas fa-map-marker-alt fa-3x" aria-hidden="true" style="margin-right: 35px;"></i></a>' +
								'</th>' + 
								'<th>' + 
								'<a href="' + URLStreetView +'" target="_blank" style="color:black;"><i class="fa fa-street-view fa-3x" aria-hidden="true" style="margin-right: 30px;"></i></a>' +
								'</th>' + 
								'<th>';  
								contentString += '<a href="javascript:gx.popup.openPrompt(' + "'gateway.Comandos_Popup.aspx'" + ',[{Ctrl:' + "'" + array[i].RastreadorId + "'" + '}])" style="color:black;"><i class="fa fa-cogs fa-3x" aria-hidden="true" fa-3x=""></i></a>';
								contentString += '</th>' + 
								'</tr>' +
								'</tbody>' + 
								'</table>' +
								'<i onclick="javascript:mythisMapBoxGL.removePonto(' + parseInt(num) +')" class="far fa-trash-alt fa-2x" aria-hidden="true" style="margin-left: 270px; margin-top: 20px;cursor: pointer;"></i>' +
								'</div>';	
								}else{
								var contentString = '<div id="content" style="padding: 5px;">'+
								'<p style="font-size: 16px; margin: auto;"><strong>' + array[i].VeiculoPlaca + '</strong></p>';
								
								//Se tiver o nome do motorista, irá adicionar no balão
								if(array[i].Motorista.length > 0){
									contentString += '<p style="font-size: 14px; margin: auto;"><strong>Motorista: </strong>' + array[i].Motorista + '</p>';
								}
								
								contentString += '<p style="font-size: 14px; margin: auto;"><strong>Ignição: </strong>' + array[i].Ignicao + ' / ' + array[i].Velocidade + ' KM/H </p>' +
								'<p style="font-size: 14px; margin: auto;"><strong>Hora GPS: </strong>' + array[i].DataHoraPosicao + '</p>' +
								'<p style="font-size: 14px; margin: auto;"><strong>Endereço: </strong>' + array[i].Endereco + '</p>' +
								'<p style="font-size: 14px; margin: auto;"><strong>Tensão da bateria: </strong>'  + array[i].TensaoBateria + '</p>' +
								'<p style="font-size: 14px; margin: auto;color:red;"><strong>'  + array[i].VeiculoRoubado + '</strong></p>' +
								'<br>' +
								'<table style="height: 40px;margin-top: 10px;margin-left: auto;width: 165px;margin-right: auto;width="266">' +
								'<tbody>' +
								'<tr>' +
								'<th>' + 
								'<a href="' + URLGoogleMaps +'" target="_blank" style="color:black;"><i class="fas fa-map-marker-alt fa-3x" aria-hidden="true" style="margin-right: 35px;"></i></a>' +
								'</th>' + 
								'<th>' + 
								'<a href="' + URLStreetView +'" target="_blank" style="color:black;"><i class="fa fa-street-view fa-3x" aria-hidden="true" ></i></a>' +
								'</th>' + 
								'</tr>' +
								'</tbody>' + 
								'</table>' +
								'<i onclick="javascript:mythisMapBoxGL.removePonto(' + parseInt(num) +')" class="far fa-trash-alt fa-2x" aria-hidden="true" style="margin-left: 270px; margin-top: 20px;cursor: pointer;"></i>' +
								'</div>';	
							}
							
							//Cria o popup para adicionar ao ponto
							var popup = new mapboxgl.Popup({ offset: 5 , className: 'popupMapBoxRastreamento'}).setHTML(contentString);
							
						}
					
						// Cria o HTML do ponto no mapa
						htmlMarker[num] = document.createElement('html');
						htmlMarker[num].style.height = '42px';
						htmlMarker[num].style.width = '43px';
						htmlMarker[num].style.cursor = 'pointer';
						
						var divPonto = document.createElement('div');
						divPonto.style.position = 'relative';
						
						var imgPonto = document.createElement('img');
						imgPonto.src = array[i].URLIcone;
						
						var spanPonto = document.createElement('span');
						spanPonto.style.position = 'absolute';
						spanPonto.style.left = '-14px';
						spanPonto.style.top = '6.5px';
						spanPonto.style.fontSize =  '12px';
						spanPonto.style.fontWeight = '800';
						spanPonto.style.fontFamily =  'Montiserrat,sans-serif';
						spanPonto.style.color = '#575B5D';
						spanPonto.style.height = '22px';
						spanPonto.style.lineHeight = '20px';
			    		spanPonto.style.verticalAlign = 'middle';
						spanPonto.style.backgroundColor = 'white';
			   			spanPonto.style.paddingLeft = '5px';
			    		spanPonto.style.paddingRight = '5px';
			    		spanPonto.style.border = '1px solid black';
			   			spanPonto.style.borderRadius = '5px';
			    		spanPonto.style.paddingBottom = '5px';
						
						spanPonto.innerText = array[i].VeiculoPlaca;
						
						divPonto.appendChild(imgPonto);
						divPonto.appendChild(spanPonto);
						htmlMarker[num].appendChild(divPonto);
						
						// Adiciona o ponto no mapa
						marker[num] = new mapboxgl.Marker(htmlMarker[num],{anchor: 'bottom'})
						.setLngLat(LatlngMarker)
						.setPopup(popup)
						.addTo(map);
						
						// Adiciona o evento para realiza o zoom no ponto ao clicar
						htmlMarker[num].addEventListener('click', function() { 
							
							var numeroMarker = htmlMarker.indexOf(this); //Busca o index do elemento do click para buscar o latlng dele
							map.flyTo({
								center: marker[numeroMarker].getLngLat(),
								zoom: 15
							});
							
						});
						
					}
					
					//Se marcou o zoom automático no final, irá setar
					if(UtilizarZoomAutomatico == true){
						
						//Caso só tenha um ponto ele irá fixar um zoom neste ponto, caso tenha mais de um ponto irá deixar um zoom maior para que o usuário consiga visualizar todos os pontos
						if(arrayLen === 1){
							map.flyTo({
								center: marker[num].getLngLat(),
								zoom: 14
							});
							}else{
							
							map.fitBounds(boundsZoom, {
								padding: 100
							});
							
						}
					}
				
				} catch (e) {
				 
				 	console.log(e);
				   
				}

		}
		this.RealizaZoom = function(Latitude ,Longitude ,SegundosParaIniciarExecucao ) {

				
				setTimeout(function(){ 
					map.flyTo({center: [parseFloat(Longitude),parseFloat(Latitude)],zoom: 19}); }
				, parseInt(SegundosParaIniciarExecucao));	
					
				

		}
		this.adicionaPontoEventoMapa = function(json ) {

			     	
				try {
					
					var array = JSON.parse(json);
					var num;
					
					arrayLen = array.length;
					
					for (i = 0; i < arrayLen; i++) {
						
						var LatlngMarker = [parseFloat(array[i].PontosLongitude) , parseFloat(array[i].PontosLatitude)];
						var num = parseInt(array[i].PontosId);
						
						//Caso já existir um ponto com este Id irá remover o ponto, para criar no novo locar (Mover o ponto)
						if(marker[num] != undefined){
							
							htmlMarker[num].remove(); //Remove o html do ponto do mapa
							marker[num].remove(); //Remove o ponto antigo
							marker[num] = undefined; //limpa a varivável do ponto antigo
							
						}
						
						
						var URLGoogleMaps = "https://www.google.com/maps/search/?api=1&query=" + array[i].PontosLatitude + "," + array[i].PontosLongitude;
						var URLStreetView = "http://maps.google.com/maps?q=&layer=c&cbll=" + array[i].PontosLatitude + "," + array[i].PontosLongitude;
						
						//Variável com o conteúdo de texto da caixa ao clicar no ponto
						var contentString = '<div id="content" style="padding: 5px;">'+
						'<p style="font-size: 16px; margin: auto;"><strong>' + array[i].VeiculoPlaca + '</strong></p>';
						
						//Se tiver o nome do motorista, irá adicionar no balão
						if(array[i].Motorista.length > 0){
							contentString += '<p style="font-size: 14px; margin: auto;"><strong>Motorista: </strong>' + array[i].Motorista + '</p>';
						}
							
						
						contentString += '<p style="font-size: 14px; margin: auto;"><strong>Endereço: </strong>' + array[i].Endereco + '</p>' +
						'<br>' +
						'<table style="height: 40px;margin-top: 10px;margin-left: auto;width: 165px;margin-right: auto;width="266">' +
						'<tbody>' +
						'<tr>' +
						'<th>' + 
						'<a href="' + URLGoogleMaps +'" target="_blank" style="color:black;"><i class="fas fa-map-marker-alt fa-3x" aria-hidden="true" style="margin-right: 35px;"></i></a>' +
						'</th>' + 
						'<th>' + 
						'<a href="' + URLStreetView +'" target="_blank" style="color:black;"><i class="fa fa-street-view fa-3x" aria-hidden="true" ></i></a>' +
						'</th>' + 
						'</tr>' +
						'</tbody>' + 
						'</table>' +
						'</div>';	
						
						// Cria o HTML do ponto no mapa
						htmlMarker[num] = document.createElement('html');
						htmlMarker[num].style.height = '42px';
						htmlMarker[num].style.width = '43px';
						htmlMarker[num].style.cursor = 'pointer';
						
						var divPonto = document.createElement('div');
						divPonto.style.position = 'relative';
						
						var imgPonto = document.createElement('img');
						imgPonto.src = array[i].URLIcone;
						
						var spanPonto = document.createElement('span');
						spanPonto.style.position = 'absolute';
						spanPonto.style.left = '3px';
						spanPonto.style.top = '6.5px';
						spanPonto.style.fontSize =  '9px';
						spanPonto.style.fontWeight = '800';
						spanPonto.style.fontFamily =  'Poppins';
						spanPonto.style.color = 'black';
						spanPonto.style.height = '20px';
						spanPonto.style.lineHeight = '20px';
			    			spanPonto.style.verticalAlign = 'middle';
						spanPonto.innerText = array[i].VeiculoPlaca;
						
						divPonto.appendChild(imgPonto);
						divPonto.appendChild(spanPonto);
						htmlMarker[num].appendChild(divPonto);
						
						//Cria o popup para adicionar ao ponto
						var popup = new mapboxgl.Popup({ offset: 5 , className: 'popupMapBoxRastreamento'}).setHTML(contentString);
						
						// Adiciona o ponto no mapa
						marker[num] = new mapboxgl.Marker(htmlMarker[num],{anchor: 'bottom'})
						.setLngLat(LatlngMarker)
						.setPopup(popup)
						.addTo(map);
						
						// Adiciona o evento para realiza o zoom no ponto ao clicar
						htmlMarker[num].addEventListener('click', function() { 
							
							var numeroMarker = htmlMarker.indexOf(this); //Busca o index do elemento do click para buscar o latlng dele
							map.flyTo({
								center: marker[numeroMarker].getLngLat(),
								zoom: 19
							});
							
						});
						
					}
					
					//Caso só tenha um ponto ele irá fixar um zoom neste ponto, caso tenha mais de um ponto irá deixar um zoom maior para que o usuário consiga visualizar todos os pontos
					if(arrayLen === 1){
						map.flyTo({
							center: marker[num].getLngLat(),
							zoom: 14
						});
					}else{
						map.flyTo({
							center: [-51.780252,-18.4551835],
							zoom: 4
						});
					}
					
				} catch (e) {
				 
				 	console.log(e);
				   
				}

		}
		this.removeTodosPontosMapa = function() {

					
				//Limpa todos pontos da tela
				for (i = 1; i < marker.length; i++) {
					
					if(marker[i] != undefined){
						marker[i].remove(); //Remove o ponto do mapa
					}
				      
				}
				
				marker = []; //Limpa a varivável dos pontos
				htmlMarker = []; //Limpa a varivável de HTML dos pontos
				pontosRemovidos = []; //Limpa a varivável dos pontos removidos
				

		}
		this.removePonto = function(IdPonto ) {

					
				marker[IdPonto].remove(); //Remove o ponto do mapa
				marker[IdPonto] = undefined; //Limpa a varivável dos pontos
				htmlMarker[IdPonto] = undefined; //Limpa a varivável de HTML dos pontos
				
				pontosRemovidos.push(IdPonto); //Adiciona na coleção os Ids que foram removidos	
				
				mythisMapBoxGL.PontoRemovidoMapa(); //Ativa um evento que o ponto foi removido	
					

		}
		this.getPontosRemovidos = function() {

			     
				var resultpontosRemovidos = JSON.stringify(pontosRemovidos);
				pontosRemovidos = [];
				
				return resultpontosRemovidos;


		}
		this.AdicionaRotaMapa = function(json ) {

				
				try {
					
					var array = JSON.parse(json);
					var arrayLen = array.length;
					var Rotas = [];
					
					//Limpa todos pontos da rota da tela
					for (i = 1; i < markerRota.length; i++) {
						
						if(markerRota[i] != undefined){
							markerRota[i].remove(); //Remove o ponto do mapa
						}
						
					}
					
					markerRota = []; //Limpa a varivável dos pontos
					htmlMarkerRota = []; //Limpa a varivável de HTML dos pontos
					
					for (i = 0; i < arrayLen; i++) {
						
						var pontosArrayLen = array[i].Pontos.length;
						var RotaPolyline = [];
						
						var num = parseInt(array[i].PolylineId);
						
						//Adiciona a lat/lng em um array para constuir o polyline
						for (j = 0; j < pontosArrayLen; j++) {
							
							RotaPolyline.push([parseFloat(array[i].Pontos[j].lng),parseFloat(array[i].Pontos[j].lat)]); 
							
							//Cria um ponto para o lat/lng inicial e final
							if(j === 0){//LatLong Inicial
								
								var LatlngMarker = [parseFloat(array[i].Pontos[j].lng),parseFloat(array[i].Pontos[j].lat)];
								var num = parseInt(array[i].Pontos[j].PontoId);
								
								var URLGoogleMaps = "https://www.google.com/maps/search/?api=1&query=" + array[i].Pontos[j].lat + "," + array[i].Pontos[j].lng;
								var URLStreetView = "http://maps.google.com/maps?q=&layer=c&cbll=" + array[i].Pontos[j].lat + "," + array[i].Pontos[j].lng;
								
								//Variável com o conteúdo de texto da caixa ao clicar no ponto
								var contentString = '<div id="content" style="padding: 5px;">'+
								'<p style="font-size: 16px; margin: auto;"><strong>' + array[i].Placa + '</strong></p>' +
								'<p style="font-size: 14px; margin: auto;"><strong>Ignição: </strong>' + array[i].Pontos[j].Ignicao + ' / ' + array[i].Pontos[j].Velocidade + ' KM/H </p>' +
								'<p style="font-size: 14px; margin: auto;"><strong>Hora GPS: </strong>' + array[i].Pontos[j].DataHoraPosicao + '</p>' +
								//'<p style="font-size: 14px; margin: auto;"><strong>Endereço: </strong>' + array[i].Endereco + '</p>' +
								//'<p style="font-size: 14px; margin: auto;"><strong>Tensão da bateria: </strong>'  + array[i].TensaoBateria + '</p>' +
								'<br>' +
								'<table style="height: 40px;margin-top: 10px;margin-left: auto;width: 165px;margin-right: auto;width="266">' +
								'<tbody>' +
								'<tr>' +
								'<th>' + 
								'<a href="' + URLGoogleMaps +'" target="_blank" style="color:black;"><i class="fas fa-map-marker-alt fa-3x" aria-hidden="true" style="margin-right: 35px;"></i></a>' +
								'</th>' + 
								'<th>' + 
								'<a href="' + URLStreetView +'" target="_blank" style="color:black;"><i class="fa fa-street-view fa-3x" aria-hidden="true" ></i></a>' +
								'</th>' + 
								'</tr>' +
								'</tbody>' + 
								'</table>' +
								'</div>';	
								
								// Cria o HTML do ponto no mapa
								htmlMarkerRota[num] = document.createElement('html');
								htmlMarkerRota[num].style.height = '32px';
								htmlMarkerRota[num].style.width = '32px';
								htmlMarkerRota[num].style.cursor = 'pointer';
								
								var divPonto = document.createElement('div');
								divPonto.style.position = 'relative';
								
								var imgPonto = document.createElement('img');
								//imgPonto.style.marginTop = '7px';
								imgPonto.src = array[i].URLIconeInicio;
								
								var spanPonto = document.createElement('span');
								spanPonto.style.position = 'absolute';
								spanPonto.style.left = '3px';
								spanPonto.style.top = '6.5px';
								spanPonto.style.fontSize =  '9px';
								spanPonto.style.fontWeight = '800';
								spanPonto.style.fontFamily =  'Poppins';
								spanPonto.style.color = 'black';
								spanPonto.style.height = '20px';
								spanPonto.style.lineHeight = '20px';
								spanPonto.style.verticalAlign = 'middle';
								
								divPonto.appendChild(imgPonto);
								divPonto.appendChild(spanPonto);
								htmlMarkerRota[num].appendChild(divPonto);
								
								//Cria o popup para adicionar ao ponto
								var popup = new mapboxgl.Popup({ offset: 5 , className: 'popupMapBoxRastreamento'}).setHTML(contentString);
								
								// Adiciona o ponto no mapa
								markerRota[num] = new mapboxgl.Marker(htmlMarkerRota[num],{anchor: 'bottom'})
								.setLngLat(LatlngMarker)
								.setPopup(popup)
								.addTo(map);
								
								// Adiciona o evento para realiza o zoom no ponto ao clicar
								htmlMarkerRota[num].addEventListener('click', function() { 
									
									var numeroMarker = htmlMarkerRota.indexOf(this); //Busca o index do elemento do click para buscar o latlng dele
									map.flyTo({
										center: markerRota[numeroMarker].getLngLat(),
										zoom: 19
									});
									
								});	
								
								
							}else{
								if(pontosArrayLen - j === 1){ //Último ponto
									
									var LatlngMarker = [parseFloat(array[i].Pontos[j].lng),parseFloat(array[i].Pontos[j].lat)];
									var num = parseInt(array[i].Pontos[j].PontoId);
									
									var URLGoogleMaps = "https://www.google.com/maps/search/?api=1&query=" + array[i].Pontos[j].lat + "," + array[i].Pontos[j].lng;
									var URLStreetView = "http://maps.google.com/maps?q=&layer=c&cbll=" + array[i].Pontos[j].lat + "," + array[i].Pontos[j].lng;
									
									//Variável com o conteúdo de texto da caixa ao clicar no ponto
									var contentString = '<div id="content" style="padding: 5px;">'+
									'<p style="font-size: 16px; margin: auto;"><strong>' + array[i].Placa + '</strong></p>' +
									'<p style="font-size: 14px; margin: auto;"><strong>Ignição: </strong>' + array[i].Pontos[j].Ignicao + ' / ' + array[i].Pontos[j].Velocidade + ' KM/H </p>' +
									'<p style="font-size: 14px; margin: auto;"><strong>Hora GPS: </strong>' + array[i].Pontos[j].DataHoraPosicao + '</p>' +
									//'<p style="font-size: 14px; margin: auto;"><strong>Endereço: </strong>' + array[i].Endereco + '</p>' +
									//'<p style="font-size: 14px; margin: auto;"><strong>Tensão da bateria: </strong>'  + array[i].TensaoBateria + '</p>' +
									'<br>' +
									'<table style="height: 40px;margin-top: 10px;margin-left: auto;width: 165px;margin-right: auto;width="266">' +
									'<tbody>' +
									'<tr>' +
									'<th>' + 
									'<a href="' + URLGoogleMaps +'" target="_blank" style="color:black;"><i class="fas fa-map-marker-alt fa-3x" aria-hidden="true" style="margin-right: 35px;"></i></a>' +
									'</th>' + 
									'<th>' + 
									'<a href="' + URLStreetView +'" target="_blank" style="color:black;"><i class="fa fa-street-view fa-3x" aria-hidden="true" ></i></a>' +
									'</th>' + 
									'</tr>' +
									'</tbody>' + 
									'</table>' +
									'</div>';	
									
									// Cria o HTML do ponto no mapa
									htmlMarkerRota[num] = document.createElement('html');
									htmlMarkerRota[num].style.height = '32px';
									htmlMarkerRota[num].style.width = '32px';
									htmlMarkerRota[num].style.cursor = 'pointer';
									
									var divPonto = document.createElement('div');
									divPonto.style.position = 'relative';
									
									var imgPonto = document.createElement('img');
									imgPonto.style.marginLeft = '10px';
									//imgPonto.style.marginTop = '9px';
									
									imgPonto.src = array[i].URLIconeFim;
									
									var spanPonto = document.createElement('span');
									spanPonto.style.position = 'absolute';
									spanPonto.style.left = '3px';
									spanPonto.style.top = '6.5px';
									spanPonto.style.fontSize =  '9px';
									spanPonto.style.fontWeight = '800';
									spanPonto.style.fontFamily =  'Poppins';
									spanPonto.style.color = 'black';
									spanPonto.style.height = '20px';
									spanPonto.style.lineHeight = '20px';
									spanPonto.style.verticalAlign = 'middle';
									
									divPonto.appendChild(imgPonto);
									divPonto.appendChild(spanPonto);
									htmlMarkerRota[num].appendChild(divPonto);
									
									//Cria o popup para adicionar ao ponto
									var popup = new mapboxgl.Popup({ offset: 5 , className: 'popupMapBoxRastreamento'}).setHTML(contentString);
									
									// Adiciona o ponto no mapa
									markerRota[num] = new mapboxgl.Marker(htmlMarkerRota[num],{anchor: 'bottom'})
									.setLngLat(LatlngMarker)
									.setPopup(popup)
									.addTo(map);
									
									// Adiciona o evento para realiza o zoom no ponto ao clicar
									htmlMarkerRota[num].addEventListener('click', function() { 
										
										var numeroMarker = htmlMarkerRota.indexOf(this); //Busca o index do elemento do click para buscar o latlng dele
										map.flyTo({
											center: markerRota[numeroMarker].getLngLat(),
											zoom: 19
										});
										
									});
									
								}else{
									//Ponto da rota
									
									var LatlngMarker = [parseFloat(array[i].Pontos[j].lng),parseFloat(array[i].Pontos[j].lat)];
									var num = parseInt(array[i].Pontos[j].PontoId);
									
									var URLGoogleMaps = "https://www.google.com/maps/search/?api=1&query=" + array[i].Pontos[j].lat + "," + array[i].Pontos[j].lng;
									var URLStreetView = "http://maps.google.com/maps?q=&layer=c&cbll=" + array[i].Pontos[j].lat + "," + array[i].Pontos[j].lng;
									
									//Variável com o conteúdo de texto da caixa ao clicar no ponto
									var contentString = '<div id="content" style="padding: 5px;">'+
									'<p style="font-size: 16px; margin: auto;"><strong>' + array[i].Placa + '</strong></p>' +
									'<p style="font-size: 14px; margin: auto;"><strong>Ignição: </strong>' + array[i].Pontos[j].Ignicao + ' / ' + array[i].Pontos[j].Velocidade + ' KM/H </p>' +
									'<p style="font-size: 14px; margin: auto;"><strong>Hora GPS: </strong>' + array[i].Pontos[j].DataHoraPosicao + '</p>' +
									//'<p style="font-size: 14px; margin: auto;"><strong>Endereço: </strong>' + array[i].Endereco + '</p>' +
									//'<p style="font-size: 14px; margin: auto;"><strong>Tensão da bateria: </strong>'  + array[i].TensaoBateria + '</p>' +
									'<br>' +
									'<table style="height: 40px;margin-top: 10px;margin-left: auto;width: 165px;margin-right: auto;width="266">' +
									'<tbody>' +
									'<tr>' +
									'<th>' + 
									'<a href="' + URLGoogleMaps +'" target="_blank" style="color:black;"><i class="fas fa-map-marker-alt fa-3x" aria-hidden="true" style="margin-right: 35px;"></i></a>' +
									'</th>' + 
									'<th>' + 
									'<a href="' + URLStreetView +'" target="_blank" style="color:black;"><i class="fa fa-street-view fa-3x" aria-hidden="true" ></i></a>' +
									'</th>' + 
									'</tr>' +
									'</tbody>' + 
									'</table>' +
									'</div>';	
									
									// Cria o HTML do ponto no mapa
									htmlMarkerRota[num] = document.createElement('html');
									htmlMarkerRota[num].style.height = '32px';
									htmlMarkerRota[num].style.width = '32px';
									htmlMarkerRota[num].style.cursor = 'pointer';
									
									var divPonto = document.createElement('div');
									divPonto.style.position = 'relative';
									
									var imgPonto = document.createElement('img');
									//imgPonto.style.marginTop = '7px';
									imgPonto.src = array[i].URLIconeDuranteTrajeto;
									
									var spanPonto = document.createElement('span');
									spanPonto.style.position = 'absolute';
									spanPonto.style.left = '3px';
									spanPonto.style.top = '6.5px';
									spanPonto.style.fontSize =  '9px';
									spanPonto.style.fontWeight = '800';
									spanPonto.style.fontFamily =  'Poppins';
									spanPonto.style.color = 'black';
									spanPonto.style.height = '20px';
									spanPonto.style.lineHeight = '20px';
									spanPonto.style.verticalAlign = 'middle';
									
									divPonto.appendChild(imgPonto);
									divPonto.appendChild(spanPonto);
									htmlMarkerRota[num].appendChild(divPonto);
									
									//Cria o popup para adicionar ao ponto
									var popup = new mapboxgl.Popup({ offset: 5 , className: 'popupMapBoxRastreamento'}).setHTML(contentString);
									
									// Adiciona o ponto no mapa
									markerRota[num] = new mapboxgl.Marker(htmlMarkerRota[num],{anchor: 'bottom'})
									.setLngLat(LatlngMarker)
									.setPopup(popup)
									.addTo(map);
									
									// Adiciona o evento para realiza o zoom no ponto ao clicar
									htmlMarkerRota[num].addEventListener('click', function() { 
										
										var numeroMarker = htmlMarkerRota.indexOf(this); //Busca o index do elemento do click para buscar o latlng dele
										map.flyTo({
											center: markerRota[numeroMarker].getLngLat(),
											zoom: 19
										});
										
									});
									
								}
							}
						}
						
						if(map.getLayer('arrow-layer') != undefined){
							map.removeLayer('arrow-layer'); //Limpa a decoração de todas as rotas
						}
						if(map.getLayer('route') != undefined){
							map.removeLayer('route'); //Limpa todas as rotas
						}
						if(map.getSource('route') != undefined){
							map.removeSource('route'); //Limpa todas as rotas
						}
					
						//Adiciona a rota no mapa
						map.addSource('route', {
							'type': 'geojson',
							'data': {
								'type': 'Feature',
								'properties': {},
								'geometry': {
									'type': 'LineString',
									'coordinates': RotaPolyline
								}
							}
						});
						map.addLayer({
							'id': 'route',
							'type': 'line',
							'source': 'route',
							'layout': {
								'line-join': 'round',
								'line-cap': 'round'
							},
							'paint': {
								'line-color': array[i].strokeColor,
								'line-width': parseInt(array[i].strokeWeight),
								'line-opacity': parseFloat(array[i].strokeOpacity)
							}
						});
						
						
						//Adiciona a seta de decoração (direção) na rota
						var url = mythisMapBoxGL.URLIconeDirecaoRota;
						map.loadImage(url, function(err, image) {
						if (err) {
							console.error('err image', err);
							return;
						}
						map.addImage('arrow', image);
						map.addLayer({
							'id': 'arrow-layer',
							'type': 'symbol',
							'source': 'route',
							'layout': {
							'symbol-placement': 'line',
							'symbol-spacing': 10,
							'icon-allow-overlap': true,
							'icon-image': 'arrow',
							'icon-size': 0.070,
							'visibility': 'visible'
							}
						});
						});
						
						//realizar um zoom no percurso
						var coordinates = map.getSource('route')._options.data.geometry.coordinates;
						
						// Pass the first coordinates in the LineString to `lngLatBounds` &
						// wrap each coordinate pair in `extend` to include them in the bounds
						// result. A variation of this technique could be applied to zooming
						// to the bounds of multiple Points or Polygon geomteries - it just
						// requires wrapping all the coordinates with the extend method.
						var bounds = coordinates.reduce(function(bounds, coord) {
						return bounds.extend(coord);
						}, new mapboxgl.LngLatBounds(coordinates[0], coordinates[0]));
						
						map.fitBounds(bounds, {
						padding: 50
						});
					   
					}
					
				}catch (e) {
					
				   console.log(e);
				   
				}
				

		}
		this.LimpaRotaMapa = function() {

				
				try {
					
					if(map.getLayer('arrow-layer') != undefined){
						map.removeLayer('arrow-layer'); //Limpa a decoração de todas as rotas
					}
					if(map.getLayer('route') != undefined){
						map.removeLayer('route'); //Limpa todas as rotas
					}
					if(map.getSource('route') != undefined){
						map.removeSource('route'); //Limpa todas as rotas
					}
					
					
					//Limpa todos pontos da rota da tela
					for (i = 0; i < markerRota.length; i++) {
						
						if(markerRota[i] != undefined){
							markerRota[i].remove(); //Remove o ponto do mapa
						}
						
					}
					
					markerRota = []; //Limpa a varivável dos pontos
					htmlMarkerRota = []; //Limpa a varivável de HTML dos pontos
					
					//Limpa animações antigas
					if(map.getLayer('pointAnimation') != undefined){
						map.removeLayer('pointAnimation');
					}
					if(map.getLayer('routeAnimation') != undefined){
						map.removeLayer('routeAnimation');
					}
					if(map.getSource('routeAnimation') != undefined){
						map.removeSource('routeAnimation');
						try {
							map.removeImage('iconAnimacaoRota');
						}catch (e) {
						}
					}
					if(map.getSource('pointAnimation') != undefined){
						map.removeSource('pointAnimation');
					}
					
				}catch (e) {
					
				   console.log(e);
				   
				}
				

		}
		this.animarRotaMapa = function(json ) {

				
				try {
					
					mythisMapBoxGL.LimpaRotaMapa(); //Limpa as rotas e animações do mapa
					
					
					var array = JSON.parse(json);
					var arrayLen = array.length;
					var indexLine = 0;
					
					for (i = 0; i < arrayLen; i++) {
						
						var pontosArrayLen = array[i].Pontos.length;
						var CoordenadasRota = [];
						var num = parseInt(array[i].PolylineId);
						
						//Adiciona a lat/lng em um array para animar
						for (j = 0; j < pontosArrayLen; j++) {
							
							CoordenadasRota.push([parseFloat(array[i].Pontos[j].lng),parseFloat(array[i].Pontos[j].lat)]); 
							
						}
						
						break;
					}	
					
					// A simple line from origin to destination.
					var routeAnimation = {
						'type': 'FeatureCollection',
						'features': [
						{
							'type': 'Feature',
							'geometry': {
								'type': 'LineString',
								'coordinates': CoordenadasRota
							}
						}
						]
					};
					
					// A single point that animates along the route.
					// Coordinates are initially set to origin.
					var pointAnimation = {
						'type': 'FeatureCollection',
						'features': [
						{
							'type': 'Feature',
							'properties': {},
							'geometry': {
								'type': 'Point',
								'coordinates': [CoordenadasRota[0]]
							}
						}
						]
					};
					
					// Calculate the distance in kilometers between route start/end point.
					for(i=0;i<2;i++) {
						var lineDistance = turf.lineDistance(routeAnimation.features[0], {units: 'kilometers'});
					}
					
					var arc = [];
					
					// Number of steps to use in the arc and animation, more steps means
					// a smoother arc and animation, but too many steps will result in a
					// low frame rate
					var steps = 1300;
					
					// Draw an arc between the `origin` & `destination` of the two points
					for (var i = 0; i < lineDistance; i += lineDistance / steps) {
						var segment = turf.along(routeAnimation.features[0], i, {units: 'kilometers'});
						arc.push(segment.geometry.coordinates);
					}
					
					// Update the route with calculated arc coordinates
					routeAnimation.features[0].geometry.coordinates = arc;
						
					// Add a source and layer displaying a point which will be animated in a circle.
					map.addSource('routeAnimation', {
						'type': 'geojson',
						'data': routeAnimation
					});
					
					map.addSource('pointAnimation', {
						'type': 'geojson',
						'data': pointAnimation
					});
					
					map.addLayer({
						'id': 'routeAnimation',
						'source': 'routeAnimation',
						'type': 'line',
						'paint': {
							'line-color': array[0].strokeColor,
							'line-width': parseInt(array[0].strokeWeight),
							'line-opacity': parseFloat(array[0].strokeOpacity)
							//'line-width': 2,
							//'line-color': '#007cbf'
						}
					});
					
					//Adiciona o icone do carro/moto/caminhão
					map.loadImage(
					array[0].URLIconAnimation,
					function(error, image) {
						if (error) throw error;
						map.addImage('iconAnimacaoRota', image);
					}
					);
					
					map.addLayer({
						'id': 'pointAnimation',
						'source': 'pointAnimation',
						'type': 'symbol',
						'layout': {
							'icon-image': 'iconAnimacaoRota',//'airport-15',
							'icon-rotate': ['get', 'bearing'],
							'icon-rotation-alignment': 'map',
							'icon-allow-overlap': true,
							'icon-ignore-placement': true
						}
					});

					
					function animate(cntr) {
						
					      // Update point geometry to a new position based on counter denoting
					      // the index to access the arc.
					      if (cntr >= routeAnimation.features[0].geometry.coordinates.length-1){
					          return;
					      }
						
						pointAnimation.features[0].geometry.coordinates = routeAnimation.features[0].geometry.coordinates[cntr];
						
						
						pointAnimation.features[0].properties.bearing = turf.bearing(
						turf.point(routeAnimation.features[0].geometry.coordinates[cntr >= steps ? cntr - 1 : cntr]),
						turf.point(routeAnimation.features[0].geometry.coordinates[cntr >= steps ? cntr : cntr + 1])
						);  
						
						// Update the source with this new data.
						map.getSource('pointAnimation').setData(pointAnimation);
						
						// Request the next frame of animation so long the end has not been reached.
						if (cntr < steps) {
							requestAnimationFrame(function(){animate(cntr+1);});
						}
						
			   		}
					
					// Start the animation.
			   		animate(0);
							
					
				}catch (e) {
					
				   console.log(e);
				   
				}
				

		}
		this.OtimizaPontosRota = function(SDTCollectionLatLngJSON ,offsetThresholdInMetres ,gapThresholdInMetres ) {

				
				//	Documentação do método
				//
				//	simplify([[lon,lat],[lon,lat],[lon,lat]], offsetThresholdInMetres, gapThresholdInMetres);
				//	path - an array of longitude,latitude pairs
				//	
				//	offsetThreshold - how far outside the straight line a point needs to be for it to be "kept"
				//	
				//	gapThreshold - if removing a point would create a segment longer than this, do not remove it
				//	
				//	Example:
				//	
				//	var coords = [ [ 15.603332, 78.227070 ],
				//			[ 15.606422, 78.226824 ],
				//			[ 15.608782, 78.226667 ],
				//			[ 15.610799, 78.226535 ] ];
				//	var result = simplify(coords, 5, 50);
				
				try {

					var JSONObj = JSON.parse(SDTCollectionLatLngJSON); //Transforma o JSON recebido em objeto
					var coords =  []; //Cria um array vazio de coordenadas
					
					//Roda o Objeto adicionando o lat/lng no array de coordenadas
					JSONObj.forEach((e) => {
						coords.push([e.Lat,e.Lng]);
					});
					
					//Simplifica os pontos da rota
					var result = simplify(coords, offsetThresholdInMetres, gapThresholdInMetres);
					
					//Transforma o resultado em um JSON para o SDT "SDTCollectionLatLngJSON"
					JSONObj = [];
					result.forEach((e) => {
						var lat = parseFloat(e[0]);
						var lng = parseFloat(e[1]);
						JSONObj.push({"Lat":e[0],"Lng":e[1]});
					});
					
					//Transforma o Objeto com os pontos simplificados em um JSON
					mythisMapBoxGL.ResultadoSimplify = JSON.stringify(JSONObj);
					//Ativa um evento na tela que os pontos foram otimizados
					mythisMapBoxGL.PontosRotaOtimizados();
					
				}catch (e) {
					
				   console.log(e);
				   
				}
				

		}
		this._removeDesenhosMapa = function() {

				
				try {
					
					var selected = draw.getSelected();
					
					if(selected.features.length > 0){
						
						//Remove o desenho pela API Draw
						draw.delete(selected.features[0].id);
						
					}else{
						
						//Remove círculos
						if(idCirculoSelecionado != undefined){
							
							//Busca o Id do circulo clicado
							for(i = 0; i < CircleResultGeocoder.length; i++){
								
								if(CircleResultGeocoder[i] != undefined){
									
									if(CircleResultGeocoder[i]._circle.properties.id === idCirculoSelecionado){
										
										CircleResultGeocoder[i].remove(); //Remove o círculo
										CircleResultGeocoder[i] = undefined; // Limpa a coleção
										idCirculoSelecionado = undefined; //Limpa o ID selecionado
										
										break; //Encontrou o círculo, sai do for
									}
									
								}
								
							}	
							
						}
					
					}
					
				}
				catch (e) {
					
				   console.log(e);
				   
				}
				

		}
		this._AdicionaCirculoMapa = function() {

				
				try {
					
					if(ControleCirculosEmUso === 'false'){
						
						//Seta que o geocoder está na tela
						ControleCirculosEmUso = 'true'
						
						//Cria a variável com o geocoder
						GeocoderCircle = new MapboxGeocoder({
							accessToken: mythisMapBoxGL.MapKey,
							mapboxgl: mapboxgl,
							placeholder: 'Buscar endereço',
							marker: false,
							language: 'pt-BR',
							countries: 'br'
						});
						
						//Adiciona o geocoder na tela
						map.addControl(
						GeocoderCircle
						,'top-right');
						
						//Altera o padding da classe de input do texto
						GeocoderCircle._inputEl.style.padding = '10px 40px 10px 35px';
						
						//Adiciona o círculo ao resultado do geocoder
						GeocoderCircle.on('result', function(e) {
							
							//Cria o novo id do circulo
							idCirculo += 1;
							
							//Adiciona o círculo ao mapa
							CircleResultGeocoder.push(new MapboxCircle({lat: e.result.center[1], lng: e.result.center[0]}, 300, {
								editable: true,
								fillColor: '#005baa',
								strokeColor: '#005baa',
								strokeWeight: 2,
								properties: {id: idCirculo}
							}).addTo(map));
							
							CircleResultGeocoder[CircleResultGeocoder.length-1].on('click', function (e) {
								
								//Ao clicar é feita uma verificação para encontrar em qual circulo clicou filtrando se o lat/long do click está dentro do circulo
								
								//Cria um ponto com o lat/lng
								var ponto = turf.point([e.lngLat.lng,e.lngLat.lat]);
								
								//Busca o Id do circulo clicado
								for(i = 0; i < CircleResultGeocoder.length; i++){
									
									if(CircleResultGeocoder[i] != undefined){
										
										//Cria um poligo com os dados do circulo
										var polygon = turf.polygon(CircleResultGeocoder[i]._getCircleGeoJSON().features[0].geometry.coordinates)
										
										if(turf.booleanPointInPolygon(ponto, polygon) === true){
											
											//Guarda o Id do círculo clicado
											idCirculoSelecionado = CircleResultGeocoder[i]._circle.properties.id
											
											break; //Encontrou o círculo, sai do for
										}
										
									}
									
								}
								
							});
							
							document.getElementById("myModalCirculo").style.display = 'block' //Mostra o modal de inserir o nome do círculo na tela
							
						});
						
					}else{
						
						//Seta que o geocoder foi removido da tela
						ControleCirculosEmUso = 'false'
						
						//Remove o geocoder da tela
						map.removeControl(GeocoderCircle);
						
					}
					
				}
				catch (e) {
					
				   console.log(e);
				   
				}
				

		}
		this._AdicionaTableBuscaNoMapa = function() {

			 	
				try {
				      
				      $("#" + mythisMapBoxGL.IdTableFerramentaDeFiltro).prependTo("#map");
					document.getElementById(mythisMapBoxGL.IdTableFerramentaDeFiltro).style.top = "5px";
					document.getElementById(mythisMapBoxGL.IdTableFerramentaDeFiltro).style.left = "8px";
					document.getElementById(mythisMapBoxGL.IdTableFerramentaDeFiltro).style.zIndex= "500";
					document.getElementById(mythisMapBoxGL.IdTableFerramentaDeFiltro).style.position= "absolute";
					
					//Caso seja usuário de rastreamento irá remover as opções "Cliente" e "Id do Módulo" do Combo
					if(mythisMapBoxGL.IsUsuarioRastreamento === 'Sim'){
						
						setTimeout(function(){ 
							 var ComboBox = document.getElementById("Combo");
							//Remove todas as opções de operadores deixando somente a de usuario de rastreamento
							//ComboBox.remove(1); //Remove a opção Cliente
							//ComboBox.remove(1); //Remove a opção Id do módulo
							ComboBox.remove(2); //Remove a opção Id do módulo
							
							//Adiciona a opção "Todos" se for cliente de rastreamento
							var option = document.createElement('option');
			   				option.text = 'Todos'; 
							option.value = 'todos';
			    				ComboBox.add(option, 2);
											
						 }, 500);	
						
					}
					
				}
				catch (e) {
					
				   console.log(e);
				   
				}
				
			 	
				
			 
		}
		this._CancelaInsercaoPoligono = function() {

				
				//Remove mensagens de erro
				document.getElementById("InputPoligono").style.borderColor = 'black'
				document.getElementById("MensagemErroNomePoligono").style.visibility = 'hidden'

				//Remove o polígono
				draw.delete(idPoligonoCriado);
				idPoligonoCriado = undefined;
					
				document.getElementById("myModal").style.display = 'none'
				document.getElementById("InputPoligono").value = ''
				

		}
		this._CancelaInsercaoCirculo = function() {

				
				//Remove mensagens de erro
				document.getElementById("InputNomeCirculo").style.borderColor = 'black'
				document.getElementById("MensagemErroNomeCirculo").style.visibility = 'hidden'
				
				//Remove o Círculo
				for(i = 0; i < CircleResultGeocoder.length; i++){
					
					if(CircleResultGeocoder[i] != undefined){
						
						//Remove o círculo
						if(idCirculo === CircleResultGeocoder[i]._circle.properties.id){
							
							CircleResultGeocoder[i].remove()
							CircleResultGeocoder[i] = undefined; // Limpa a coleção
							idCirculoSelecionado = undefined; //Limpa o ID selecionado
							
							break; //Removeu o círculo, sai do for
							
						}
						
					}
					
				}
				
				//Remove o modal de inserir o nome da tela
				document.getElementById("myModalCirculo").style.display = 'none'
				document.getElementById("InputNomeCirculo").value = ''	
			     

		}
		this._VerificaErrosNomeCirculo = function() {

				
				var NomeCirculo = '';
				NomeCirculo = document.getElementById("InputNomeCirculo").value; //Recupera o nome do círculo informado
				var ExisteErroNomeCirculo = 'false';
				
				if(NomeCirculo === ''){
					
					//Nome não preenchido, seta erro
					ExisteErroNomeCirculo = 'true';
					
				}else{
					
					//Verifica se existe um círculo com nome repetido
					for(i = 0; i < CircleResultGeocoder.length; i++){
						
						if(CircleResultGeocoder[i] != undefined){
							
							//Guarda o Id do círculo clicado
							if(NomeCirculo === CircleResultGeocoder[i]._circle.properties.name){
								
								ExisteErroNomeCirculo = 'true';
								
								break; //Encontrou um circulo com nome repetido, sai do for
								
							}
							
						}
						
					}			
					
				}

				if(ExisteErroNomeCirculo === 'false'){
					
					//Remove mensagens de erro
					document.getElementById("InputNomeCirculo").style.borderColor = 'black'
					document.getElementById("MensagemErroNomeCirculo").style.visibility = 'hidden'
					
					//Sucesso na inserção
					for(i = 0; i < CircleResultGeocoder.length; i++){
						
						if(CircleResultGeocoder[i] != undefined){
							
							//Guarda o Id do círculo clicado
							if(idCirculo === CircleResultGeocoder[i]._circle.properties.id){
								
								CircleResultGeocoder[i]._circle.properties.name = NomeCirculo
								
								break; //Encontrou um circulo com nome repetido, sai do for
								
							}
							
						}
						
					}
					
					//Remove o modal de inserir o nome da tela
					document.getElementById("myModalCirculo").style.display = 'none'
			     		document.getElementById("InputNomeCirculo").value = ''
					
				}else{
					
					//Informa mensagem de erro
					document.getElementById("InputNomeCirculo").style.borderColor = 'red'
					document.getElementById("MensagemErroNomeCirculo").style.visibility = 'visible'
					
				}
			     

		}
		this._VerificaErrosNomePoligono = function() {

					
				
				var data = draw.getAll(); //Busca todos os dados de desenho pela draw API

				var NomePoligono = '';
				NomePoligono = document.getElementById("InputPoligono").value;
				
				var ExisteErroNomePoligono = 'false';
				
				if(NomePoligono === ''){
					
					//Nome não preenchido, seta erro
					ExisteErroNomePoligono = 'true';
					
				}else{
					for(i = 0; i < data.features.length; i++){
						//Verifica se o nome digitado para o polígono é repetido
						if(data.features[i].geometry.type === 'Polygon'){
							if(data.features[i].properties.name === NomePoligono){
								ExisteErroNomePoligono = 'true';
								break; //Sai do for
							}
						}
					}	
				}
				
				if(ExisteErroNomePoligono === 'false'){
					
					//Remove mensagens de erro
					document.getElementById("InputPoligono").style.borderColor = 'black'
					document.getElementById("MensagemErroNomePoligono").style.visibility = 'hidden'
					
					//Sucesso na inserção
					
					//Adiciona o nome do polígono
					for(i = 0; i < data.features.length; i++){
						if(data.features[i].id === idPoligonoCriado){
							data.features[i].properties.name = NomePoligono
						}
					}
					
					draw.deleteAll(); //Deleta todos os objetos do mapa
				      draw.add(data); //Adiciona o GeoJson com o nome do polígono
					
					document.getElementById("myModal").style.display = 'none'
				      document.getElementById("InputPoligono").value = ''
					
				}else{
				
					//Informa mensagem de erro
					document.getElementById("InputPoligono").style.borderColor = 'red'
					document.getElementById("MensagemErroNomePoligono").style.visibility = 'visible'
					
				}
			     

		}
		this._VerificaErrosNomeRota = function() {

				
				var data = draw.getAll(); //Busca todos os dados de desenho pela draw API
				
				var NomeRota = '';
				NomeRota = document.getElementById("InputRota").value; //Recupera o nome da rota informado
				var LarguraRota = 0;
				LarguraRota = document.getElementById("InputLarguraRota").value; //Recupera a largura da rota informada
				
				var ExisteErroNomeRota = 'false';
				
				if(NomeRota === ''){
					
					//Nome não preenchido, seta erro
					ExisteErroNomeRota = 'true';
					
				}else{
					
					//Verifica se existe uma rota com nome repetido
					for(i = 0; i < data.features.length; i++){
						//Verifica se o nome digitado para o polígono é repetido
						if(data.features[i].geometry.type === 'LineString'){
							if(data.features[i].properties.name === NomeRota){
								ExisteErroNomeRota = 'true';
								break; //Sai do for
							}
						}
					}
				}
				
				//Informou a largura
				if(LarguraRota > 0){
					
					//Remove mensagens de erro
					document.getElementById("InputLarguraRota").style.borderColor = 'black'
					document.getElementById("MensagemLarguraRota").style.visibility = 'hidden'
					
					if(ExisteErroNomeRota === 'false'){
						
						//Remove mensagens de erro
						document.getElementById("InputRota").style.borderColor = 'black'
						document.getElementById("MensagemErroNomeRota").style.visibility = 'hidden'
						
						//Sucesso na inserção
						NomeRotaAdicionada = NomeRota;
						LarguraRotaAdicionada = LarguraRota;
						
						// Remove o modal da tela
						document.getElementById("myModalRota").style.display = 'none'
				      	document.getElementById("InputRota").value = ''
						document.getElementById("InputLarguraRota").value = 0
						
					}else{
						
						//Informa mensagem de erro
						document.getElementById("InputRota").style.borderColor = 'red'
						document.getElementById("MensagemErroNomeRota").style.visibility = 'visible'
						
					}
				     
					
				}else{
					
					//Informa mensagem de erro
					document.getElementById("InputLarguraRota").style.borderColor = 'red'
					document.getElementById("MensagemLarguraRota").style.visibility = 'visible'
					
				}
				

		}
		this._ShowToast = function() {


			  var x = document.getElementById("snackbar");
			  x.className = "show";
			  setTimeout(function(){ x.className = x.className.replace("show", ""); }, 3000);


		}
		this._CalculaDistancia = function() {

					
				try {
					
					if(CalcularDistanciaEmUso === 'false'){
						
						CalcularDistanciaEmUso = 'true';
						
						var distanceContainer = document.getElementById('distance');
						
						// GeoJSON object to hold our measurement features
						var geojsonDistancia = {
							'type': 'FeatureCollection',
							'features': []
						};
					 
						// Used to draw a line between points
						var linestring = {
							'type': 'Feature',
							'geometry': {
								'type': 'LineString',
								'coordinates': []
							}
						};
						
					 
						map.addSource('geojsonDistancia', {
							'type': 'geojson',
							'data': geojsonDistancia
						});
					 
						// Add styles to the map
						map.addLayer({
							id: 'measure-points',
							type: 'circle',
							source: 'geojsonDistancia',
							paint: {
								'circle-radius': 5,
								'circle-color': '#000'
							},
							filter: ['in', '$type', 'Point']
						});
						map.addLayer({
							id: 'measure-lines',
							type: 'line',
							source: 'geojsonDistancia',
							layout: {
								'line-cap': 'round',
								'line-join': 'round'
							},
							paint: {
								'line-color': '#000',
								'line-width': 2.5
							},
							filter: ['in', '$type', 'LineString']
						});
					 	
						map.on('click', function(e){
							
							if(CalcularDistanciaEmUso === 'true'){
								
								var features = map.queryRenderedFeatures(e.point, {
									layers: ['measure-points']
								});
							 
								// Remove the linestring from the group
								// So we can redraw it based on the points collection
								if (geojsonDistancia.features.length > 1) geojsonDistancia.features.pop();
							 
								// Clear the Distance container to populate it with a new value
								distanceContainer.innerHTML = '';
							 
								// If a feature was clicked, remove it from the map
								if (features.length) {
									var id = features[0].properties.id;
									geojsonDistancia.features = geojsonDistancia.features.filter(function(point) {
										return point.properties.id !== id;
									});
									} else {
									var point = {
										'type': 'Feature',
										'geometry': {
											'type': 'Point',
											'coordinates': [e.lngLat.lng, e.lngLat.lat]
										},
										'properties': {
											'id': String(new Date().getTime())
										}
									};
								 
									geojsonDistancia.features.push(point);
								}
							 
								if (geojsonDistancia.features.length > 1) {
									linestring.geometry.coordinates = geojsonDistancia.features.map(function(
									point
									) {
										return point.geometry.coordinates;
									});
								 
									geojsonDistancia.features.push(linestring);
								 
									// Populate the distanceContainer with total distance
									var value = document.createElement('pre');
									value.textContent =
									'Distância Total: ' +
									turf.length(linestring).toLocaleString() +
									'km';
									distanceContainer.appendChild(value);
								}
							 
								map.getSource('geojsonDistancia').setData(geojsonDistancia);
							}
						
						});
					 
						map.on('mousemove', function(e) {
							if(CalcularDistanciaEmUso === 'true'){
								var features = map.queryRenderedFeatures(e.point, {
									layers: ['measure-points']
								});
								// UI indicator for clicking/hovering a point on the map
								map.getCanvas().style.cursor = features.length
								? 'pointer'
								: 'crosshair';
							}
						});	
					
					}else{
						
						CalcularDistanciaEmUso = 'false';
						
						map.removeLayer('measure-points');
						
						map.removeLayer('measure-lines');
						
						var distanceContainer = document.getElementById('distance');
						distanceContainer.removeChild(distanceContainer.lastElementChild);
						
						map.getCanvas().style.cursor = 'pointer';
						
						map.removeSource('geojsonDistancia');
					
					}
					
					
				}
				catch (e) {
					
				   console.log(e);
				   
				}
			     

		}
		this._openCloseMenuMapa = function() {

				
				try {

					if(MenuOpen === false){
						document.getElementById("mySidenav").style.width = "350px";
						document.getElementById("mySidenav").style.paddingLeft = "10px";
						document.getElementById("mySidenav").style.paddingRight = "10px";
						MenuOpen = true;
					}else{
						document.getElementById("mySidenav").style.width = "0";
						document.getElementById("mySidenav").style.paddingLeft = "0px";
						document.getElementById("mySidenav").style.paddingRight = "0px";
						MenuOpen = false;
					}  
					
				}
				catch (e) {
					
				   console.log(e);
				   
				}
				
			 
		}
		this._openCloseControleRotas = function() {

			 	
				// map.getSource('directions') - Busca os pontos da rota
				
				try {
				      
				     if(ControleRotasEmUso === 'false'){
						
						ControleRotasEmUso = 'true'
						
						controleRoteirizador = new MapboxDirections({
							accessToken: mythisMapBoxGL.MapKey,
							profile: 'mapbox/driving',
							unit: 'metric',
							language: 'pt-BR',
							alternatives: true
							});
						
						map.addControl(controleRoteirizador,'top-right');
						
						//Remove o botão de reverse (está bugando recarregando a tela toda)
						document.getElementsByClassName('directions-icon directions-icon-reverse directions-reverse js-reverse-inputs')[0].remove()
						
						if(mythisMapBoxGL.AdicionarControleDeDesenho === 'Sim'){
							
							//Mostra o modal de inserir os dados da rota caso esteja utilizando o modo de desenho
							//controleRoteirizador.on('destination', function(e) {
								//mythisMapBoxGL.salvaDesenhosMapa();
								////document.getElementById("myModalRota").style.display = 'block' 	
							//});
						}
							
					}else{
					
						ControleRotasEmUso = 'false'
						
						map.removeControl(controleRoteirizador);
						
					}
					
				}
				catch (e) {
					
				   console.log(e);
				   
				}
				
			 	
				
			 
		}


		this.onPontoRemovidoMapaHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
			}

			if (this.PontoRemovidoMapa) {
				this.PontoRemovidoMapa();
			}
		} 

		this.onDesenhosSalvosMapaHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
			}

			if (this.DesenhosSalvosMapa) {
				this.DesenhosSalvosMapa();
			}
		} 

		this.onPontosRotaOtimizadosHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
			}

			if (this.PontosRotaOtimizados) {
				this.PontosRotaOtimizados();
			}
		} 

		this.onSairHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
			}

			if (this.Sair) {
				this.Sair();
			}
		} 

	this.autoToggleVisibility = true;

	var childContainers = {};
	this.renderChildContainers = function () {
		$container
			.find("[data-slot][data-parent='" + this.ContainerName + "']")
			.each((function (i, slot) {
				var $slot = $(slot),
					slotName = $slot.attr('data-slot'),
					slotContentEl;

				slotContentEl = childContainers[slotName];
				if (!slotContentEl) {				
					slotContentEl = this.getChildContainer(slotName)
					childContainers[slotName] = slotContentEl;
					slotContentEl.parentNode.removeChild(slotContentEl);
				}
				$slot.append(slotContentEl);
				$(slotContentEl).show();
			}).closure(this));
	};

}