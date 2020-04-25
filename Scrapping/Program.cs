using HtmlAgilityPack;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Scrapping
{
    class Program
    {
        static void Main(string[] args)
        {
			//Probando cambios.
			string html = getHtmlBookTest();
			List<LoanCity> loanCity = LibraryScrapping.GetLoanCityBook(html);
			//LibraryService libraryService = new LibraryService();
			//string codeAPI = LibraryService.GetCodeApiHTTP();
			////libraryService.CodeApi = "O9473/ID91fd4fa3";

			//if (codeAPI != "")
			//{
			//	string codeExit = "";
			//	string search = "";
			//	string numberBook = "";
			//	string html = "";
			//	do
			//	{
			//		Console.WriteLine("Write Book Search Library:");
			//		search = Console.ReadLine();
			//		Console.WriteLine("Number book list:");
			//		numberBook = Console.ReadLine();
			//		html = LibraryService.GetHtmlSearchHTTP(search, Int32.Parse(numberBook), codeAPI);
			//		List<Book> listBook = LibraryScrapping.GetBooksSearch(html);

			//		Book book = listBook.ElementAt(0);
			//		html = LibraryService.GetHtmlLoanBook(book.ACC, book.DOC, codeAPI);
			//		List<LoanCity> loanCity = LibraryScrapping.GetLoanCityBook(html);
			//		Console.WriteLine("Continue press S if you want exit press N");
			//		codeExit = Console.ReadLine();
			//	}
			//	while (codeExit != "N");

			//}
		}

		static string getHtmlBookTest()
        {
			return @"
<html xmlns=""""http://www.w3.org/1999/xhtml"" xml:lang=""es-ES"">

<head>
    <!-- Copyright (c) 1999-2011, baratz  Servicios de Teledocumentacion, S.A. http://www.baratz.es (Red de Bibliotecas de la Comunidad de Madrid) -->
    <!-- compilation: ""Mar  5 2020"" date: ""2020-03-27 00:11:39"" version: ""2.2""-->
    <!-- abnetcl: ""Nov_13_2019_2_2"" -->
    <!-- REQUEST_SCHEME: ""http"" -->
    <!-- HTTPS: """" -->
    <!-- log level: ""1"" -->
    <!-- log file: """" -->
    <!-- log configuration file: """" -->
    <meta http-equiv=""Expires"" content=""Fri, 1 Jan 1999 08:00:00 WET"">
    <meta http-equiv=""Pragma"" content=""no-cache"">
    <meta name=""viewport"" content=""width=device-width; initial-scale=1.0"">
    <meta http-equiv=""Content-Type"" content=""application/vnd.wap.xhtml+xml; charset=iso-8859-1"">
    <meta name=""HandheldFriendly"" content=""True"">
    <meta name=""format-detection"" content=""telephone=no"">
    <link rel=""canonical"" href=""https://gestiona3.madrid.org:443/mopac/cgi-bin/abnetopac?TITN=1587959"">
    <title>Catálogos de las Bibliotecas de la Comunidad de Madrid It :</title>
    <link rel=""stylesheet"" href=""/mopac/imag/style1.css"" type=""text/css"">
    <script type=""text/javascript"">this.sDirHttp = ""/mopac"";
        function timeout() { parent.parent.document.location = ""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf?ACC=301""; } window.setTimeout(timeout, 392000);
    </script>
    <script type=""text/javascript"" src=""/mopac/js/utils.js""></script>
    <script type=""text/javascript"" src=""/mopac/js/jquery.min.js""></script>
    <script type=""text/javascript"" src=""/mopac/js/jquery.slimmenu.js""></script>
    <link rel=""shortcut icon"" type=""image/x-icon"" href=""/mopac/favicon.ico"">
    <meta name=""theme-color"" content=""#BC0031"">
</head>

<body style="""">
    <p id=""back-top"" style=""display: block;""><a id=""back-to-top"" href=""#top"" title=""""><i class=""fa fa-angle-up""></i></a>
    </p>
    <div class=""acenter"">
        <style>
            #head {
                position: relative;
            }

            .btn_barcode {
                position: absolute;
                background-color: transparent;
                border: 0;
                width: 70px;
                right: 25px;
                top: 15%;
            }

            .c-modal_barcode .c-modal-body {
                text-align: center;
            }

            .c-modal_barcode .c-modal-footer {
                text-align: center;
            }

            .c-modal_barcode .c-modal-body #lectBCTop {
                margin: 0 auto;
                width: 100% !important;
            }

            .c-modal_barcode .c-modal-body #lectBCTop object {
                width: 100% !important;
                max-width: 324px;
            }

            .c-modal_barcode .c-modal_close {
                border: 0;
                background-color: transparent;
                font-size: 2em;
            }

            .h-ds {
                height: 100%;
                overflow: hidden;
            }

            .c-modal {
                position: fixed;
                top: 0;
                left: 0;
                width: 100%;
                height: 100%;
                z-index: 9999;
                background: rgba(11, 11, 11, .65)
            }

            .c-modal .c-modal-dialog--400 {
                width: 95%;
                max-width: 400px
            }

            .c-modal .c-modal-dialog--500 {
                width: 95%;
                max-width: 500px
            }

            .c-modal .c-modal-dialog--800 {
                width: 95%;
                max-width: 800px
            }

            .c-modal .c-modal-dialog--1024 {
                width: 95%;
                max-width: 1024px
            }

            .c-modal .c-modal-dialog--1280 {
                width: 95%;
                max-width: 1280px
            }

            .c-modal .c-modal-dialog {
                margin: 0 auto;
                background-color: #fff;
                border-radius: 5px;
                position: relative;
                top: 25%
            }

            @media (max-width:960px) {
                .c-modal .c-modal-dialog {
                    position: fixed;
                    top: 50%;
                    left: 50%;
                    -webkit-transform: translateX(-50%) translateY(-50%);
                    -ms-transform: translateX(-50%) translateY(-50%);
                    transform: translateX(-50%) translateY(-50%)
                }
            }

            .c-modal .c-modal-dialog .c-modal-content {
                padding: 10px 15px
            }

            .c-modal .c-modal-dialog .c-modal-content .c-modal-header {
                display: -webkit-box;
                display: -ms-flexbox;
                display: flex;
                -webkit-box-align: center;
                -ms-flex-align: center;
                align-items: center;
                -webkit-box-pack: end;
                -ms-flex-pack: end;
                justify-content: flex-end;
                position: -webkit-sticky;
                position: sticky;
                top: 0;
                background-color: #fff;
                z-index: 999
            }

            .c-modal .c-modal-dialog .c-modal-content .c-modal-header .c-modal-title {
                float: left;
                text-align: left;
                -webkit-box-flex: 1;
                -ms-flex-positive: 1;
                flex-grow: 1;
                margin: 5px 0;
                padding: 10px 15px;
                font-size: 1em;
                font-weight: 400
            }

            .c-modal .c-modal-dialog .c-modal-content .c-modal-header>button {
                float: right;
                display: -webkit-box;
                display: -ms-flexbox;
                display: flex;
                -webkit-box-align: center;
                -ms-flex-align: center;
                align-items: center
            }

            .c-modal .c-modal-dialog .c-modal-content .c-modal-header:after {
                clear: both;
                content: """";
                display: table
            }

            .c-modal .c-modal-dialog .c-modal-content .c-modal-header--line {
                border-bottom: 1px dotted #ededed
            }

            .c-modal .c-modal-dialog .c-modal-body {
                padding: 5px 0
            }

            .c-modal .c-modal-dialog .c-modal-body .c-modal-body_title {
                margin: 0;
                padding: 5px 0;
                text-align: center;
                font-weight: 400;
                font-size: 1.2em
            }

            .c-modal .c-modal-dialog .c-modal_body--300 {
                height: 300px;
                overflow: auto
            }

            .c-modal .c-modal-dialog .c-modal-footer {
                text-align: center;
                border-top: 1px solid #f7f7f8;
                padding: 10px 15px
            }

            @media (max-width:960px) and (orientation:landscape) {
                .c-modal--land .c-modal-dialog {
                    -webkit-transform: unset;
                    -ms-transform: unset;
                    transform: unset;
                    width: 95%;
                    height: 100%;
                    margin: 0 auto;
                    display: block;
                    overflow: auto;
                    position: static
                }
            }

            .c-modal--dn {
                display: none
            }
        </style>
        <script type=""text/javascript"" src=""/mopac/js/jquery-barcode-last.min.js""></script>
        <script>
            var abnOpac = abnOpac || {};
            abnOpac.modules = abnOpac.modules || {};
            abnOpac.modules.o_Roller = function (a, t, e, o) {
                function n(t, o) { this.$roller = t, this.$rollerDest, this.$rollerDestClose, this.$full, this.options = { dest: """", action: """", full: !1, fullClass: ""h-full"", disableScroll: !1, addClass: """", closeButton: """", outerClick: !1, callBackOpen: function () { }, callBackClose: function () { } }, this.checked = 0, a.extend(this.options, o) }
                return n.prototype._common = { $body: a(""body"") }, n.prototype.init = function () { var t = this; t.$rollerDest = a(""."" + t.options.dest), t.$rollerDest.length && (t.options.full && (t.$full = a('<div class=""' + t.options.fullClass + '""></div>'), t.$full.insertBefore(t.$rollerDest)), """" != t.options.closeButton && (t.$rollerDestClose = t.$rollerDest.find(""."" + t.options.closeButton)), t.$rollerDest.is("":visible"") && (t.checked = 1), t._events()) }, n.prototype._events = function () { var o = this; o.$roller.on(""click"", function (t) { t.preventDefault(), o.open() }), o.options.full && o.$full.on(""click"", function (t) { t.preventDefault(), o.close() }), """" != o.options.closeButton && o.$rollerDestClose.length && o.$rollerDestClose.on(""click"", function (t) { t.preventDefault(), o.close() }), o.options.outerClick && o.$rollerDest.on(""click"", function (t) { t.target == this && o.close() }), a(e).on({ keyup: function (t) { 27 == t.keyCode && o.$rollerDest.is("":visible"") && o.close() } }) }, n.prototype.close = function () { var t = this; t.checked && (t.$rollerDest.scrollTop(0), t.$rollerDest.removeAttr(""tabindex""), ""addClass"" != t.options.action ? t.$rollerDest.hide() : t.$rollerDest.removeClass(t.options.addClass), t.options.full && t.$full.hide(), t._common.$body.removeClass(""h-ds""), t.$roller.focus(), t.checked = 0), t.options.callBackClose(t.$rollerDest) }, n.prototype.open = function () {
                    var t = this, o = 0; switch (t.checked = 1, t.options.full && t.$full.show(), t.options.disableScroll && t._common.$body.addClass(""h-ds""), t.options.action) { case ""fadeToggle"": o = t.$rollerDest.is("":visible"") ? (t.close(), 0) : (t.$rollerDest.fadeIn(), 1); break; case ""show"": o = t.$rollerDest.is("":visible"") ? (t.close(), 0) : (t.$rollerDest.show(), 1); break; case ""addClass"": t.$rollerDest.addClass(t.options.addClass), o = 1 }
                    o ? t.$rollerDest.attr(""tabindex"", -1).focus() : t.$roller.focus(), t.options.callBackOpen(t.$rollerDest)
                }, a.fn.extend({ abnRoller: function (o) { return this.each(function () { var t = a(this); t.data(""o_roller"") || (t.data(""o_roller"", 1), new n(t, o).init()) }) } }), n
            }(jQuery, window, document);
            $(document).ready(function () {
                var $modalBarcode = $("".c-modal_barcode"");
                var $btnBarcode = $("".btn_barcode"");
                if ($modalBarcode.length) {
                    $btnBarcode.abnRoller({
                        dest: ""c-modal_barcode"",
                        action: ""fadeToggle"",
                        closeButton: ""c-modal_close"",
                        disableScroll: true,
                        outerClick: true
                    });
                    $modalBarcode.find(""#lectBCTop"").barcode(""000000000"", ""code39"", { barWidth: 2, barHeight: 100, bgColor: 'f9f9f9', showHRI: false, output: ""bmp"" });
                }
                else {
                    $btnBarcode.find(""img"").attr(""title"", ""Identificarse"").attr(""alt"", ""Identificarse"");
                    $btnBarcode.on(""click"", function (event) {
                        var $titsectionUser = $("".titsection.user"");
                        $titsectionUser.click();
                        $('html,body').animate({
                            scrollTop: $titsectionUser.offset().top
                        }, 'slow');
                    });
                }
            });
        </script>
        <div id=""head"">

            <div class=""logo"">

                <img id=""logo"" src=""/mopac/imag/media/commadrid.png"" alt=""Bibliotecas de la Comunidad de Madrid"">


            </div>
            <button type=""button"" class=""btn_barcode"">
                <span></span>
                <img src=""/mopac/imag/media/button_barcode.png"" alt=""Identificarse"" title=""Identificarse"">
            </button>
        </div>
        <div id=""loading""></div>
        <script>var acc = { exit: '/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT1?ACC=301', home: '/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT1?ACC=101', bookmark: '/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT1?ACC=260', search: '/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT1?ACC=120' }</script>
        <div class=""navi"">
            <div class=""menu-collapser""><a href=""#"" class=""icon-exit""></a><a href=""#"" class=""icon-home""></a><a href=""#""
                    class=""icon-bookmark""></a><a href=""#"" class=""icon-search""></a>
                <div class=""collapse-button""><span class=""icon-bar""></span><span class=""icon-bar""></span><span
                        class=""icon-bar""></span></div>
            </div>
            <ul id=""navigation"" class=""slimmenu collapsed"" style=""display: none;"">
                <li><a href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=301"">Salir</a></li>
                <li><a href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=101""
                        title=""Visualizar la lista de documentos marcados"">Inicio</a></li>
                <li><a href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=260"" title=""%ld reserva(s)"">Marcados</a>
                </li>
                <li><a href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=120"" title="""">Buscar</a></li>

                <li><a href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=300&amp;HELPID=DOC"">Ayuda</a></li>
            </ul>
        </div>
    </div>
    <div id=""userConnect"">
        <div class=""titsection user"" onclick=""showHide(this)""><strong>Área de usuario</strong>
            <div class=""expand""></div>
        </div>
        <div class=""hide"">
            <form action=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT1"" method=""post"" id=""abnopid"" name=""abnopid""
                onsubmit=""AbnOpacId();return false;"">
                <input type=""hidden"" name=""ACC"" value=""201"">
                <input type=""hidden"" name=""FBC"" value=""316"">
                <input type=""hidden"" name=""NAC"" value=""317"">
                <input type=""text"" id=""leid"" name=""leid"" autocomplete=""off""
                    placeholder=""Nº de carné / Correo electrónico"" required="""">
                <input type=""password"" id=""lepass"" name=""lepass"" placeholder=""contraseña"" required="""">
                <div class=""err""></div><br>
                <input id=""logButt"" type=""submit"" name=""submit"" value=""Conectar"">
                <a href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT1?ACC=218"" class=""c-login_reset"">¿Has olvidado tu
                    contraseña?</a>


            </form>
        </div>

    </div>
    <div class=""navButt"">
        <a href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf?ACC=161&amp;DOC=6""
            onclick=""AbnOpacListDoc('6');return false;"">
            <i class=""fa fa-angle-double-left"" aria-hidden=""true""></i>
            Resultados
        </a>

    </div>
    <div class=""section resDoc"">
        <div class=""titsection"">
            <strong>Búsqueda General</strong>
        </div>
        <form action=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19"" method=""post"" id=""abnform"" name=""abnform"">
            <input type=""hidden"" name=""ACC"" value=""165"">
            <input type=""hidden"" name=""DOC"" value=""6"">
            <input type=""hidden"" name=""BRS"" value="""">
        </form>

        <form action=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19"" method=""post"" id=""abnhist"" name=""abnhist"">
            <input type=""hidden"" name=""ACC"" value=""137"">
            <input type=""hidden"" name=""DOC"" value=""6"">
            <input type=""hidden"" name=""BRS"" value="""">
            <div class=""acenter""><select id=""xshist"" name=""xshist"" onchange=""AbnChgHist();"">
                    <option value=""1"">Cualquier campo: it stephen/</option>
                    <option value=""2"">Cualquier campo: it/</option>
                </select>
                <br><strong>en&nbsp;Todas las bibliotecas</strong></div>
        </form>

        <div class=""counter"">

            <a href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=165&amp;DOC=5""
                onclick=""AbnOpacDoc(5);return false;"" class=""recordset prev"">«</a>

            Registro 6 de 115

            <a href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=165&amp;DOC=7""
                onclick=""AbnOpacDoc(7);return false;"" class=""recordset next"">»</a>

        </div>
        <div class=""dvDoc"">
            <div class=""docList"">
                <p id=""docLeft"">
                    <a href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf?ACC=294&amp;DOC=6&amp;MLKOB=270989254343""
                        class=""cover"" title=""Cubierta"" target=""_blank""><img
                            src=""https://gestiona3.madrid.org/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf?ACC=307&amp;MLKOB=270989254343""
                            url=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf?ACC=307&amp;MLKOB=270989254343""
                            onload=""putUrl(this)""
                            style=""padding: 0.2em; margin: 0.2em; box-shadow: rgba(0, 0, 0, 0.7) 0px 2px 5px;""></a>

                </p>
                <form action=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19"" method=""post"" id=""abndocu"" name=""abndocu"">
                    <input type=""hidden"" name=""ACC"" value=""223"">
                    <input type=""hidden"" name=""ADDDES_READ"" value=""1"">
                    <div class=""overData"">
                        <div class=""listadoc"">
                            <div class=""dvdoc entity"">
                                <div class=""auth""><strong>Título:</strong></div>
                                <div class=""titn""><span style=""color:#f00"">It</span> : (Eso) / dirigida por Andy
                                    Muschietti; guión Chase Palmer, Cary Fukunaga y Gary Dauberman</div>
                                <div class=""auth""><strong>Publicación:</strong></div>
                                <div class=""titn"">Madrid : Warner Bross Entertainment España : 2017<br>
                                </div>
                                <div class=""auth""><strong>Descripción física:</strong></div>
                                <div class=""titn"">1 DVD-Video (ca. 129 min.) : son., col. ; 12 cm<br>
                                </div>
                                <div class=""auth""><strong>Tipo de contenido:</strong></div>
                                <div class=""titn"">Imagen (en movimiento ; bidimensional) </div>
                                <div class=""auth""><strong>Tipo de medio:</strong></div>
                                <div class=""titn"">vídeo </div>
                                <div class=""auth""><strong>Nota general:</strong></div>
                                <div class=""titn"">Basada en la novela homónima de <span
                                        style=""color:#f00"">Stephen</span> King<br>
                                </div>
                                <div class=""auth""><strong>Intérpretes:</strong></div>
                                <div class=""titn"">Bill Skarsgård, Jaeden Lieberher, Sophia Lillis, Finn Wolfhard, Wyatt
                                    Oleff, Jeremy Ray Taylor, Jack Dylan Grazer, Chosen Jacobs, Nicholas Hamilton, Jake
                                    Sim, Logan Thompson, Owen Teague, Jackson Robert Scott, Javier Botet, <span
                                        style=""color:#f00"">Stephen</span> Bogaert, Stuart Hughes, Geoffrey Pounsett,
                                    Megan Charpentier, Isabelle Nelisse, Tatum Lee<br>
                                </div>

                                <div class=""auth""><strong>Fecha/Lugar acontecimiento:</strong></div>
                                <div class=""titn"">Largometraje producido por Estados Unidos realizado en 2017<br>
                                </div>
                                <div class=""auth""><strong>Resumen:</strong></div>
                                <div class=""titn"">""Cuando empiezan a desparecer niños en el pueblo de Derry (Maine), un
                                    pandilla de amigos lidia con sus mayores miedos al enfrentarse a un malvado payaso
                                    llamado Pennywise, cuya historia de asesinatos y violencia data de
                                    siglos.""--Filmaffinity<br>
                                </div>

                                <div class=""auth""><strong>Destinatario:</strong></div>
                                <div class=""titn"">No recomendada para menores de 16 años<br>
                                </div>

                                <div class=""auth""><strong>Lengua:</strong></div>
                                <div class=""titn"">Versión original en inglés doblada en español y alemán con subtítulos
                                    opcionales en español, alemán, noruego y sueco y subtítulos opcionales para personas
                                    con discapacidad auditiva en inglés y alemán<br>
                                </div>
                                <div class=""auth""><strong>Depósito Legal:</strong></div>
                                <div class=""titn"">M 31143-2017, Oficina Depósito Legal Madrid<br>
                                </div>
                                <div class=""auth""><strong>Número de videograbación:</strong></div>
                                <div class=""titn"">FS SES 8478309 Warner Bros<br>
                                </div>

                                <div class=""auth""><strong>Género</strong>:</div>
                                <div class=""titn""><a
                                        href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf?ACC=133&amp;NAUT=420845&amp;SAUT=Cine+de+terror+"">Cine
                                        de terror </a>tgfbne<br>
                                </div>
                                <div class=""auth""><strong>Autores/Autoras:</strong></div>
                                <div class=""titn""><a
                                        href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf?ACC=133&amp;NAUT=470849&amp;SAUT=Muschietti,+Andy,+"">Muschietti,
                                        Andy, </a><a
                                        href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf?ACC=133&amp;NAUT=133317&amp;SAUT=director+de+cine"">director
                                        de cine</a>&nbsp;&nbsp;<a
                                        href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf?ACC=138&amp;AUTZS=ZZ0470849:ADJ2:ZZ0133317"">(+)</a><br>
                                    <a
                                        href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf?ACC=133&amp;NAUT=397682&amp;SAUT=Fukunaga,+Cary+(1977-),+"">Fukunaga,
                                        Cary (1977-), </a><a
                                        href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf?ACC=133&amp;NAUT=574306&amp;SAUT=guionista"">guionista</a>&nbsp;&nbsp;<a
                                        href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf?ACC=138&amp;AUTZS=ZZ0397682:ADJ2:ZZ0574306"">(+)</a><br>
                                    <a
                                        href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf?ACC=133&amp;NAUT=640914&amp;SAUT=Dauberman,+Gary,+"">Dauberman,
                                        Gary, </a><a
                                        href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf?ACC=133&amp;NAUT=574306&amp;SAUT=guionista"">guionista</a>&nbsp;&nbsp;<a
                                        href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf?ACC=138&amp;AUTZS=ZZ0640914:ADJ2:ZZ0574306"">(+)</a><br>
                                </div>
                            </div>
                        </div><!-- Campos con etiquetas especiales --><input type=""hidden"" name=""wntitn""
                            value=""1587959""><input type=""hidden"" name=""wntitl"" value=""It : ""><input type=""hidden""
                            name=""wnauth"" value="""">
                    </div>
                    <ul class=""social_links"">

                        <li class=""buttonCheck""><a href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf?ACC=261""
                                onclick=""AbnOpacCheckDoc(this);return false;""><img src=""/mopac/imag/check0.gif""
                                    alt=""Marcar""></a></li>
                    </ul>
                    <script type=""text/javascript"">plSocial();</script>

                </form>
            </div>
            <div class=""library"">
                <div class=""title_library"">
                    <h3>Ejemplares</h3>
                </div>
                <ul>

                    <li class=""clear""><strong>Biblioteca</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=271&amp;BI=RBMALB"">ALCOBENDAS.
                            Mediatecas de Alcobendas</a></li>


                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMALB3"">Mediateca Anabel
                            Segura</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;DVD Prestable</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DV AD it&amp;BC=1500333649"">DV
                            AD it</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMALB1"">Mediateca Pablo
                            Iglesias</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;DVD Prestable</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DV TE it&amp;BC=1500090566"">DV
                            TE it</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clear""><strong>Biblioteca</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=271&amp;BI=RBMARA"">ARANJUEZ.
                            Biblioteca Municipal de Aranjuez</a></li>


                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMARA1"">Biblioteca
                            Municipal Álvarez de Quindós</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Audiovisuales&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=1281061935"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clear""><strong>Biblioteca</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=271&amp;BI=BRCM"">Biblioteca
                            Regional de Madrid Joaquín Leguina</a></li>


                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BR01"">Biblioteca
                            Regional de Madrid Joaquín Leguina</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Depósito Legal&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;No prestable a domicilio</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=17/31143&amp;BC=1847041"">17/31143</a>
                    </li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clear""><strong>Biblioteca</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=271&amp;BI=RBMBOA"">BOADILLA DEL
                            MONTE. Bibliotecas Municipales de Boadilla del Monte</a></li>


                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMBOA1"">Biblioteca
                            Municipal de Boadilla del Monte</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=1500140719"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMBOA2"">Biblioteca
                            Municipal José Ortega y Gasset</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=1500140720"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clear""><strong>Biblioteca</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=271&amp;BI=RBMCVI"">COLMENAR VIEJO.
                            Bibliotecas Municipales de Colmenar Viejo</a></li>


                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMCVI1"">Biblioteca
                            Municipal Miguel de Cervantes</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT 1&amp;BC=1071101843"">DVD
                            P-TE IT 1</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMCVI2"">Biblioteca
                            Municipal Pablo Ruiz Picasso</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT 1&amp;BC=1071101776"">DVD
                            P-TE IT 1</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clear""><strong>Biblioteca</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=271&amp;BI=RBMFNT"">FUENTIDUEÑA DE
                            TAJO. Biblioteca Municipal de Fuentidueña de Tajo</a></li>


                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMFNT1"">Biblioteca
                            Municipal Luis Cubero</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=791.43(086.82)&amp;BC=1201019001"">791.43(086.82)</a>
                    </li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clear""><strong>Biblioteca</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=271&amp;BI=RBMGET"">GETAFE. Red de
                            Bibliotecas Municipales de Getafe</a></li>


                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMGET3"">José Luis
                            Sampedro</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=119182"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clear""><strong>Biblioteca</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=271&amp;BI=BPM"">MADRID. Bibliotecas
                            Públicas</a></li>


                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BCDIU"">ARGANZUELA. BP
                            Pío Baroja</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=VIV SUS IT&amp;BC=1400578383"">VIV
                            SUS IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BCDIG"">BARAJAS. BP
                            Gloria Fuertes</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=VID SUS IT&amp;BC=1400578369"">VID
                            SUS IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BCDIX"">CENTRO. BP Benito
                            Pérez Galdós</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=VID SUS IT&amp;BC=1400578386"">VID
                            SUS IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BP06"">CENTRO. BP Pedro
                            Salinas</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Audiovisuales&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=1500039774"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BCDIF"">CHAMARTÍN. BP
                            Francisco Ibañez</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=VIV SUS IT&amp;BC=1400578368"">VIV
                            SUS IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BP05"">CHAMBERÍ. BP José
                            Luis Sampedro</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Audiovisuales&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=9127851"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BP17"">CHAMBERÍ. BP Ruiz
                            Egea</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Audiovisuales&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=7013219"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BCDIS"">CIUDAD LINEAL. BP
                            Ciudad Lineal</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=VID SUS IT&amp;BC=1400578381"">VID
                            SUS IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BCDIL"">CIUDAD LINEAL. BP
                            Pablo Neruda</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=VID SUS IT&amp;BC=1400578374"">VID
                            SUS IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BCDIR"">FUENCARRAL-EL
                            PARDO. BP José Saramago</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=VID SUS IT&amp;BC=1400578380"">VID
                            SUS IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible después de 24/04/2020</cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BCDIA"">HORTALEZA. BP
                            Huerta de la Salud</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=VIV SUS IT&amp;BC=1400578363"">VIV
                            SUS IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BCDI8"">HORTALEZA. BP
                            María Lejárraga</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=VID SUS IT&amp;BC=1400578395"">VID
                            SUS IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BCDIK"">LATINA. BP
                            Aluche</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=VID SUS IT&amp;BC=1400578373"">VID
                            SUS IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BCDI3"">LATINA. BP Ángel
                            González</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=VID SUS IT&amp;BC=1400578390"">VID
                            SUS IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BP10"">LATINA. BP Antonio
                            Mingote</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Audiovisuales&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=7773349"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BP02"">MONCLOA-ARAVACA.
                            BP Acuña</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Audiovisuales&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=1500032735"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BCDIH"">MORATALAZ. BP
                            Miguel Delibes</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=VID SUS IT&amp;BC=1400578370"">VID
                            SUS IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BP13"">MORATALAZ. BP
                            Moratalaz</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Audiovisuales&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=2364565"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BP14"">PUENTE DE
                            VALLECAS. BP Paco Rabal</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Audiovisuales&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=2266683"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BCDIJ"">PUENTE DE
                            VALLECAS. BP Portazgo</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=VID SUS IT&amp;BC=1400703316"">VID
                            SUS IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BCDIQ"">PUENTE DE
                            VALLECAS. BP Pozo Tío Raimundo</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=VIV SUS IT&amp;BC=1400578379"">VIV
                            SUS IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BCDIV"">PUENTE DE
                            VALLECAS. BP Vallecas</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=VID SUS IT&amp;BC=1400578384"">VID
                            SUS IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible después de 24/04/2020</cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BP16"">RETIRO. BP Elena
                            Fortún</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Audiovisuales&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=1500008496"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BCDI5"">RETIRO. BP
                            Eugenio Trías</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=VIV SUS IT&amp;BC=1400578392"">VIV
                            SUS IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BCDIC"">SAN BLAS. BP
                            Canillejas</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=VIV SUS IT&amp;BC=1400578365"">VIV
                            SUS IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BCDIW"">SAN BLAS. BP José
                            Hierro</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=VID SUS IT&amp;BC=1400578385"">VID
                            SUS IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BCDIO"">SAN BLAS. BP San
                            Blas</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=VID SUS IT&amp;BC=1400578377"">VID
                            SUS IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BCDIT"">TETUÁN. BP María
                            Zambrano</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=VIV SUS IT&amp;BC=1400578382"">VIV
                            SUS IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BCDI2"">TETUÁN. BP
                            Vázquez Montalbán</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=VID SUS IT&amp;BC=1400578389"">VID
                            SUS IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BCDII"">USERA. BP García
                            Márquez</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=VID SUS IT&amp;BC=1400578371"">VID
                            SUS IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BP18"">USERA. BP José
                            Hierro</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=2350487"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BCDIP"">VICÁLVARO. BP
                            Francisco Ayala</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=VID SUS IT&amp;BC=1400578378"">VID
                            SUS IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BCDIE"">VICÁLVARO. BP
                            Vicálvaro</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=VID SUS IT&amp;BC=1400578367"">VID
                            SUS IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BCDIY"">VILLA DE
                            VALLECAS. BP Gerardo Diego</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=VID SUS IT&amp;BC=1400578387"">VID
                            SUS IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BP20"">VILLA DE VALLECAS.
                            BP Luis Martín Santos</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Audiovisuales&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=5819027"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BP21"">VILLAVERDE. BP
                            María Moliner</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Audiovisuales&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=CINE DVD P-TE IT&amp;BC=2352652"">CINE
                            DVD P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clear""><strong>Biblioteca</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=271&amp;BI=RBMMEC"">MECO. Biblioteca
                            Municipal de Meco</a></li>


                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMMEC1"">Biblioteca
                            Municipal de Meco</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=1500082084"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clear""><strong>Biblioteca</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=271&amp;BI=RBMMRZ"">MORALZARZAL.
                            Biblioteca Municipal de Moralzarzal</a></li>


                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMMRZ1"">Biblioteca
                            Municipal Casa Grande</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD TER it&amp;BC=1500185104"">DVD
                            TER it</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clear""><strong>Biblioteca</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=271&amp;BI=RBMMOS"">MÓSTOLES.
                            Bibliotecas Municipales</a></li>


                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMMOS1"">B. Móstoles
                            CENTRAL</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=P-TE IT&amp;BC=1500101829"">P-TE
                            IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMMOS6"">B. Móstoles
                            COIMBRA</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=P-TE IT&amp;BC=1500106086"">P-TE
                            IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMMOS2"">B. Móstoles EL
                            SOTO</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=P-TE IT&amp;BC=1500100888"">P-TE
                            IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMMOS5"">B. Móstoles
                            NORTE-UNIVERSIDAD</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=P-TE IT&amp;BC=1500100913"">P-TE
                            IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clear""><strong>Biblioteca</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=271&amp;BI=RBMNAL"">NAVALCARNERO.
                            Biblioteca Municipal de Navalcarnero</a></li>


                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMNAL1"">Biblioteca
                            Municipal José María Bausá</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=1231046739"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clear""><strong>Biblioteca</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=271&amp;BI=RBMRVM"">RIVAS
                            VACIAMADRID. Bibliotecas Municipales de Rivas Vaciamadrid</a></li>


                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMRVM2"">B.M. José
                            Saramago</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Audiovisuales&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=Terror IT&amp;BC=1500212538"">Terror
                            IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clear""><strong>Biblioteca</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=271&amp;BI=RBMSSR"">SAN SEBASTIÁN DE
                            LOS REYES. Bibliotecas Municipales de S. Sebastián de los Reyes</a></li>


                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMSSR1"">Biblioteca
                            Municipal Marcos Ana</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=1500297900"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clear""><strong>Biblioteca</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=271&amp;BI=MUNI"">Servicios de
                            Extensión Bibliotecaria</a></li>


                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BB01"">Bibliobuses</a>
                    </li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Bibliobús 13&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=9338168"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible después de 24/04/2020</cite></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Bibliobús 9&nbsp;<span class=""last-news""><img
                                src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=9338166"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Bibliobús 8&nbsp;<span class=""last-news""><img
                                src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=9338165"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Bibliobús 7&nbsp;<span class=""last-news""><img
                                src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=9338164"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Bibliobús 5&nbsp;<span class=""last-news""><img
                                src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=9338162"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Bibliobús 12&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=9338158"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Bibliobús 2&nbsp;<span class=""last-news""><img
                                src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=9338157"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Fondo común&nbsp;<span class=""last-news""><img
                                src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=9338167"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Bibliobús 10&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=9338169"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Bibliobús 11&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=9338163"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clear""><strong>Biblioteca</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=271&amp;BI=RBMSOT"">SOTO DEL REAL.
                            Biblioteca Municipal de Soto de Real</a></li>


                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMSOT1"">Biblioteca
                            Municipal Pedro de Lorenzo</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Audiovisuales&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=1500089731"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clear""><strong>Biblioteca</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=271&amp;BI=RBMTAL"">TALAMANCA DE
                            JARAMA. Biblioteca Municipal de Talamanca de Jarama</a></li>


                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMTAL1"">Biblioteca
                            Municipal de Talamanca de Jarama</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Audiovisuales&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=1500123080"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clear""><strong>Biblioteca</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=271&amp;BI=RBMTOR"">TORREJÓN DE
                            ARDOZ. Bibliotecas Municipales de Torrejón de Ardoz</a></li>


                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMTOR3"">Biblioteca
                            Enrique Tierno Galván</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=1500420902"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible después de 24/04/2020</cite></li>

                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMTOR2"">Biblioteca
                            Federico García-Lorca</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=1500420720"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clear""><strong>Biblioteca</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=271&amp;BI=RBMTRC"">TORREJÓN DE LA
                            CALZADA. Biblioteca Municipal</a></li>


                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMTRC1"">Biblioteca
                            Municipal María Moliner</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=1500116942"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clear""><strong>Biblioteca</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=271&amp;BI=RBMTRE"">TRES CANTOS.
                            Bibliotecas Municipales Tres Cantos</a></li>


                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMTRE1"">Biblioteca
                            Municipal Lope de Vega</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Audiovisuales&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD TER it&amp;BC=1131067642"">DVD
                            TER it</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clear""><strong>Biblioteca</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=271&amp;BI=RBMVDE"">VALDEMORO.
                            Bibliotecas Municipales de Valdemoro</a></li>


                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMVDE3"">Biblioteca
                            Municipal Centro de la Estación</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=1151115122"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clear""><strong>Biblioteca</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=271&amp;BI=RBMVNV"">VILLANUEVA DE LA
                            CAÑADA. Biblioteca Municipal de Villanueva de la Cañada</a></li>


                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMVNV1"">VILLANUEVA DE LA
                            CAÑADA. Biblioteca Municipal Fernando Lázaro Carreter</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Sala adultos&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=1002246184"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>

                    <li class=""clear""><strong>Biblioteca</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=271&amp;BI=RBMVVO"">VILLAVICIOSA DE
                            ODÓN. Biblioteca Municipal de Villaviciosa de Odón</a></li>


                    <li class=""li-break""><strong>Sucursal</strong>: <a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=273&amp;SU=BMVVO1"">Biblioteca
                            Municipal Luis de Góngora</a></li>

                    <li class=""clearn""><strong>Localización:</strong>&nbsp;Audiovisuales&nbsp;<span
                            class=""last-news""><img src=""/mopac/imag/new.gif"" title=""Novedad"" alt=""Novedad""></span></li>
                    <li class=""clearn""><strong>Tipo de ejemplar:</strong>&nbsp;Prestable. Mat. especiales</li>
                    <li class=""clearn""><strong>Signatura:</strong>&nbsp;<a
                            href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=143&amp;SIGN=DVD P-TE IT&amp;BC=1271052252"">DVD
                            P-TE IT</a></li>
                    <li class=""clearn""><strong>Soporte:</strong>&nbsp;Vídeo (DVD)</li>
                    <li class=""clearn""><cite>Disponible<span>&nbsp;</span></cite></li>


                </ul>
                <div class=""ej-dis"">Nº de ejemplares disponibles: <strong>70</strong><br>Nº de veces prestado:
                    <strong>1397</strong></div>

            </div>
            <script>
                function addes() {
                    var form = document.abndocu;
                    if (form) {
                        for (var i = 0; i < form.length; i++) {
                            form.elements[i].value = form.elements[i].value.replace(/\r?\n/g, '');
                        } document.abndocu.submit();
                    }
                }
            </script>

            <a name=""comments""></a>
            <div class=""library"">
                <div class=""title_library"">
                    <h3>Opiniones de los lectores sobre este título</h3>
                </div>

                <div class=""coment"">
                    <span class=""num-star star3""><img src=""/mopac/imag/est3.png"" alt=""Valoración""
                            onload=""addStar(this)"">&nbsp;</span>
                    <span class=""num-day"">23/11/2019 00:00</span><br>
                    <div><cite>Crítica</cite>, <strong>por: <a
                                href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf?ACC=126&amp;leal=McRodry""
                                title=""Títulos comentados por: McRodry"">McRodry</a></strong><br><span
                            class=""coment-summary"">Capítulo uno de la nueva versión deesta novela de Stephen King. Les
                            gustará a los adolescentes.</span></div>
                </div>

                <div class=""coment"">
                    <span class=""num-star star3""><img src=""/mopac/imag/est3.png"" alt=""Valoración""
                            onload=""addStar(this)"">&nbsp;</span>
                    <span class=""num-day"">31/05/2018 00:00</span><br>
                    <div><cite>Nota</cite>, <strong>por: <a
                                href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf?ACC=126&amp;leal=McRodry""
                                title=""Títulos comentados por: McRodry"">McRodry</a></strong><br><span
                            class=""coment-summary""></span></div>
                </div>

            </div>
            <fieldset>
                <script type=""text/javascript"">
                    //Comentarios para lectores identificados
                    var logLector = 0;
                </script>

                <script type=""text/javascript"">
                    if (!logLector) {
                        writeTag('<legend class=""addcomtag""><strong>Identifícate para opinar</strong><div class=""add""></div></legend>');
                    }
                </script>
                <legend class=""addcomtag""><strong>Identifícate para opinar</strong>
                    <div class=""add""></div>
                </legend>
            </fieldset>




            <a name=""links""></a>
            <div class=""library"">
                <div class=""title_library"">
                    <h3>Enlaces del registro</h3>
                </div>
                <div class=""links-reg"">
                    <form action=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19"" method=""post"" id=""ablkdocs""
                        name=""ablkdocs"">
                        <input type=""hidden"" name=""ACC"" value=""181"">
                        <input type=""hidden"" name=""EXP"" value=""""><br>

                        Otras obras de:<ul class=""list-margin"">


                            <li><a href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=181&amp;EXP=(Muschietti Andy)[T700]""
                                    onclick=""AbnLinkBdoc(this);return false;"">Muschietti, Andy, </a></li>

                            <li><a href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=181&amp;EXP=(Fukunaga Cary)[T700]""
                                    onclick=""AbnLinkBdoc(this);return false;"">Fukunaga, Cary (</a></li>

                            <li><a href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=181&amp;EXP=(Dauberman Gary)[T700]""
                                    onclick=""AbnLinkBdoc(this);return false;"">Dauberman, Gary, </a></li>

                        </ul>

                        Otras ediciones de:<ul class=""list-margin"">


                            <li><a href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=181&amp;EXP=(It)[T245]""
                                    onclick=""AbnLinkBdoc(this);return false;"">It : </a></li>

                        </ul>

                    </form>

                </div>
            </div>
        </div>
        <div class=""counter"">

            <a href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=165&amp;DOC=5""
                onclick=""AbnOpacDoc(5);return false;"" class=""recordset prev"">«</a>

            Registro 6 de 115

            <a href=""/mopac/cgi-bin/abnetopac/O9766/ID69f23cbf/NT19?ACC=165&amp;DOC=7""
                onclick=""AbnOpacDoc(7);return false;"" class=""recordset next"">»</a>

        </div>
    </div>
    <div class=""copy"">
        <span>
            <img src=""/mopac/imag/media/logopie.png"" alt="""">
            <p>© BPCM 2013-2016</p>
        </span>
        <span>
            <a href=""https://www.comunidad.madrid/servicios/informacion-atencion-ciudadano/sugerencias-quejas-agradecimientos""
                target=""_blank"">Sugerencias y quejas</a>
            <a href=""http://www.madrid.org/cs/Satellite?pagename=ComunidadMadrid/Comunes/Presentacion/popUp&amp;language=es&amp;c=CM_Texto_FA&amp;cid=1142636148876""
                target=""_blank"">Aviso legal</a>
        </span>
        <span>
            <a href=""mailto:redbibliotecasmadrid@madrid.org"">Contacto</a>
            <a href=""http://www.madrid.org/cs/Satellite?pagename=ComunidadMadrid/Comunes/Presentacion/popUp&amp;language=es&amp;c=CM_Texto_FA&amp;cid=1109266097450""
                target=""_blank"" accesskey=""5"">Accesibilidad</a>
        </span>
    </div>
    <script type=""text/javascript"" src=""/mopac/js/hammer.min.js""></script>
    <script>
        function AbnChgHist() {
            document.abnhist.submit();
        }
        function AbnOpacDoc(ndoc) {
            var ndoc = parseInt(ndoc, 10);
            if (ndoc < 1 || ndoc > 115 || isNaN(ndoc))
                return;
            Loading();
            document.abnform.DOC.value = ndoc;
            document.abnform.ACC.value = 165;
            document.abnform.submit();
        }
        function AbnOpacListDoc(n) {
            var ndoc = parseInt(n, 10);
            if (ndoc < 1 || ndoc > 115 || ndoc == 115 == 1)
                return;
            var acc = Number(""0"") ? 163 : 161;
            document.abnform.DOC.value = ndoc;
            document.abnform.ACC.value = acc;
            document.abnform.submit();
        }
        function AbnOpacCheckDoc(obj) {
            var param = ""&ACC=261&httprequest=1""; responsePost(""./"", param); putCheck(obj);
        }
        Hammer(document).on(""swipeleft"", function () { AbnOpacDoc(7); });
        Hammer(document).on(""swiperight"", function () { AbnOpacDoc(5); });
        vistaPrevia(1);
    </script>



</body>

</html>
";
        }
        static string getHtmlTest()
        {
            return @"<?xml version=""1.0""?>
<!DOCTYPE html
	PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"" xml:lang=""es-ES"">

<head>
	<!-- Copyright (c) 1999-2011, baratz  Servicios de Teledocumentacion, S.A. http://www.baratz.es (Red de Bibliotecas de la Comunidad de Madrid) -->
	<!-- compilation: ""Nov 12 2019"" date: ""2019-12-12 17:10:46"" version: ""2.2""-->
	<!-- abnetcl: ""Nov_13_2019_2_2"" -->
	<!-- REQUEST_SCHEME: ""http"" -->
	<!-- HTTPS: """" -->
	<!-- log level: ""1"" -->
	<!-- log file: """" -->
	<!-- log configuration file: """" -->
	<meta http-equiv=""Expires"" content=""Fri, 1 Jan 1999 08:00:00 WET"" />
	<meta http-equiv=""Pragma"" content=""no-cache"" />
	<meta http-equiv=""Content-Type"" content=""text/html; charset=iso-8859-1"" />
	<link rel=""canonical"" href=""https://gestiona3.madrid.org:443/biblio_publicas/cgi-bin/abnetopac?ACC=101"" />
	<title>Cat�logos de las Bibliotecas de la Comunidad de Madrid absysNET Opac</title>
	<link rel=""stylesheet"" href=""/biblio_publicas/imag/style1.css"" type=""text/css"" />
	<script type=""text/javascript"">this.sDirHttp = ""/biblio_publicas"";
		function timeout() { parent.parent.document.location = ""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=301""; } window.setTimeout(timeout, 392000);
	</script>
	<script type=""text/javascript"" src=""/biblio_publicas/js/utils.js""></script>
	<meta name=""theme-color"" content=""#024467"" />
	<link rel=""shortcut icon"" type=""image/x-icon"" href=""/biblio_publicas/favicon.png"" />
</head>

<body>
	<div id=""skiplinks"">
		<a href=""#skip"" accesskey=""s"">Saltar contenido</a> |
	</div>
	<div id=""access"">
		<a href=""#usuari_lnk"">Usuario</a> |
		<a href=""#tools_lnk"">Inf. Biblioteca</a> |
		<a href=""#contact_lnk"">Pi� de p�gina</a>
		<h1>absysNET Opac 2.0</h1>
		<h2>
			[ <acronym lang=""en"" xml:lang=""en"" title=""Web Accessibility Initiative"">WAI</acronym> &middot;
			<acronym lang=""en"" xml:lang=""en"" title=""Web Accessibility Test"">TAW</acronym> &middot;
			<acronym lang=""en"" xml:lang=""en"" title=""Cascading Style Sheets"">CSS</acronym> &middot;
			JavaScript &middot;
			<acronym lang=""en"" xml:lang=""en"" title=""eXtensible HyperText Markup Language"">XHTML</acronym> ]
		</h2>
	</div>
	<div id=""main"">
		<div class=""menu"">

			<a href=""http://www.madrid.org"" title=""Comunidad de Madrid"" target=""_blank""><img id=""comMad""
					src=""/biblio_publicas/imag/especificas/commadrid.png"" alt=""Comunidad de Madrid"" /></a>


			<a href=""http://www.madrid.org/bibliotecas"" title=""Bibliotecas de la Comunidad de Madrid""
				target=""_blank""><img id=""bcoMad"" src=""/biblio_publicas/imag/especificas/logoPeq.png""
					alt=""Bibliotecas de la Comunidad de Madrid"" /></a>
		</div>
		<div class=""empty""></div>
		<div id=""loading"">Procesando, espere por favor...<br /><img src=""/biblio_publicas/imag/loading1.gif""
				alt=""loading.."" /><br /></div>
		<div id=""catMenu"">
			<ul>
				<li><a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=101"" accesskey=""1""
						title=""Volver a la p�gina principal del Opac"">Inicio</a>
				</li>
				<li><a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=120"" accesskey=""2""
						title=""Regresar al formulario de consulta"">Buscar</a></li>
				<li>

					<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=260"" id=""no_items""
						class=""no_items"" title=""Visualizar la lista de documentos marcados""
						onclick=""javascript:void(null);return false;"">Marcados</a>


				</li>
				<li><a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=300&amp;HELPID=START""
						accesskey=""3"" title=""Ayuda sobre esta pantalla"">Ayuda</a>
				</li>
				<li><a href=""#"" onclick=""cierra('userpass')"">�rea de usuario<i class=""fa question-circle"">&#xf059;
							<div id=""mensajeLogin"">Servicio disponible para usuarios registrados en la biblioteca.</div>
						</i>
					</a>
					<h2 class=""nd"">Usuario<span class=""anchor""><a name=""usuari_lnk""></a></span></h2>
					<ul id=""userpass"">
						<fieldset title=""Formulario de identificaci�n de usuarios"">
							<legend>Formulario de identificaci�n de usuarios</legend>
							<form action=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1"" method=""post""
								id=""abnopid"" name=""abnopid"">
								<input type=""hidden"" name=""FBC"" value=""316"" />
								<input type=""hidden"" name=""NAC"" value=""317"" />
								<input type=""hidden"" name=""ACC"" value=""201"" />

								<noscript><input type=""hidden"" name=""NSSL"" value=""1"" /></noscript>
								<!--label for=""leid"">N� de carn� / Correo electr�nico</label>
<span class=""lectorleid""><label for=""lepass"">contrase�a</label></span-->
								<li>
									<i class=""fa user fa-fw"">&#xf007;</i>
									<input type=""text"" name=""leid"" id=""leid"" placeholder=""N� de carn�""
										title=""N� de carn� de la biblioteca"" />
								</li>
								<li>
									<i class=""fa key fa-fw"">&#xf084;</i>
									<input type=""password"" name=""lepass"" id=""lepass"" maxlength=""63""
										placeholder=""Contrase�a"" title=""Contrase�a"" />
									<p class=""errorlog""><span></span></p>
								</li>
								<!--div class=""lectoradd""-->
								<li class=""lectoradd"">
									<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=218""
										target=""_blank""
										onclick=""openw(this,550,(agentBrowser('Chrome'))?400:340);return false;"">�Has
										olvidado tu contrase�a?</a>

								</li>

								<script type=""text/javascript"">/*<![CDATA[*/
									writeTag('<li class=""logBut""><a href=""#"" onclick=""AbnOpacId();return false;"" class=""butt_send"">Conectar</a></li>'/*]]>*/);
									--></script>
								<!--/div-->
								<noscript><input type=""submit"" class=""butt_send"" value=""Conectar"" /></noscript>
							</form>
						</fieldset>

					</ul>
				</li>
			</ul>
		</div>
		<div class=""container"">
			<div class=""content"" id=""search"">
				<script type=""text/javascript"" src=""/biblio_publicas/js/jquery.min.js""></script>
				<script type=""text/javascript"" src=""/biblio_publicas/js/fakeMenu.js""></script>
				<div id=""results"" class=""results"">
					<h2><a name=""skip""></a><i class=""fa tags fa-fw"">&#xf02c;</i>B�squeda Avanzada</h2>
					<div class=""listadoc"">
						<form action=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1"" method=""post""
							id=""abnoplist"" name=""abnoplist"">
							<input type=""hidden"" name=""ACC"" value=""161"" />
							<input type=""hidden"" name=""DOC"" value="""" />
							<input type=""hidden"" name=""LISTMOSAIC"" value="""" />
						</form>
						<br />
						<form action=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1"" method=""post""
							name=""abnform"">
							<input type=""hidden"" name=""ACC"" value=""131"" />
							<input type=""hidden"" name=""xsface"" value=""on"" />
							<input type=""hidden"" name=""xsfind"" value=""1"" />
							<div class=""break newsearch"">
								<input type=""text"" name=""xsqf01"" id=""xsqf01"" class=""inpsearch"" value=""coco"" />
								<script type=""text/javascript"">/*<![CDATA[*/
										writeTag('<a href=""#"" onclick=""OpenLinkSrch();return false;"" class=""butt_send findstart"">Buscar</a>');
/*]]>*/</script>
								<noscript><input type=""submit"" class=""butt_send"" value=""Buscar"" /></noscript>
								<select onchange=""ChgSubcat();"" id=""subcat"" name=""subcat"">
									<option selected=""selected"" value=""/"">Todas las bibliotecas</option>
									<option value=""BR"">Biblioteca Regional</option>
									<option value=""ESCOL"">Bibliotecas escolares</option>
									<option value=""EXBIB"">Extensi�n bibliotecaria</option>
									<option value=""EXBIB/MUNI"">&nbsp;&nbsp;&gt;Servicios de Extensi�n Bibliotecaria
									</option>
									<option value=""EXBIB/MUNI/BB01"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Bibliobuses</option>
									<option value=""EXBIB/MUNI/BMETRO"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Bibliometro
									</option>
									<option value=""EXBIB/MUNI/BRED"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Bibliored</option>
									<option value=""EXBIB/MUNI/BP25"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Telebiblioteca
									</option>
									<option value=""BPCM"">Redes de Bibliotecas P�blicas</option>
									<option value=""BPCM/RBMALM"">&nbsp;&nbsp;&gt;ALAMO. Biblioteca Municipal de El �lamo
									</option>
									<option value=""BPCM/RBMALM/BMALM1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal de El �lamo</option>
									<option value=""BPCM/RBMALC"">&nbsp;&nbsp;&gt;ALCAL� DE HENARES. Bibliotecas
										Municipales Alcal�</option>
									<option value=""BPCM/RBMALC/BMALC1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B.P.M. Cardenal
										Cisneros</option>
									<option value=""BPCM/RBMALC/BMALC6"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B.P.M. Jos�
										Chac�n</option>
									<option value=""BPCM/RBMALC/BMALC8"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B.P.M. La Galatea
									</option>
									<option value=""BPCM/RBMALC/BMALC3"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B.P.M. Mar�a
										Moliner</option>
									<option value=""BPCM/RBMALC/BMALC7"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B.P.M. Mar�a
										Zambrano</option>
									<option value=""BPCM/RBMALC/BMALC2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B.P.M. P�o Baroja
									</option>
									<option value=""BPCM/RBMALC/BMALC5"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B.P.M. Rafael
										Alberti</option>
									<option value=""BPCM/RBMALC/BMALC4"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B.P.M. Rosa
										Chacel</option>
									<option value=""BPCM/RBMALB"">&nbsp;&nbsp;&gt;ALCOBENDAS. Mediatecas de Alcobendas
									</option>
									<option value=""BPCM/RBMALB/BMALB3"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Mediateca Anabel
										Segura</option>
									<option value=""BPCM/RBMALB/BMALB2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Mediateca Centro
										de Arte</option>
									<option value=""BPCM/RBMALB/BMALB4"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Mediateca Miguel
										Delibes</option>
									<option value=""BPCM/RBMALB/BMALB1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Mediateca Pablo
										Iglesias</option>
									<option value=""BPCM/RBMALR"">&nbsp;&nbsp;&gt;ALCORC�N. Bibliotecas Municipales de
										Alcorc�n</option>
									<option value=""BPCM/RBMALR/BMALR5"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Ciudad
										de Nejapa</option>
									<option value=""BPCM/RBMALR/BMALR1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca El
										Parque</option>
									<option value=""BPCM/RBMALR/BMALR4"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca El
										Pinar</option>
									<option value=""BPCM/RBMALR/BMALR7"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Fuente
										Cisneros</option>
									<option value=""BPCM/RBMALR/BMALR3"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Joaqu�n Vilumbrales</option>
									<option value=""BPCM/RBMALR/BMALR2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Jos�
										Hierro</option>
									<option value=""BPCM/RBMALR/BMALR6"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Miguel
										Delibes</option>
									<option value=""BPCM/RBMALG"">&nbsp;&nbsp;&gt;ALGETE. Biblioteca Municipal de Algete
									</option>
									<option value=""BPCM/RBMALG/BMALG1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Miguel de Cervantes</option>
									<option value=""BPCM/RBMALP"">&nbsp;&nbsp;&gt;ALPEDRETE. Biblioteca Municipal de
										Alpedrete</option>
									<option value=""BPCM/RBMALP/BMALP1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal de Alpedrete</option>
									<option value=""BPCM/RBMARA"">&nbsp;&nbsp;&gt;ARANJUEZ. Biblioteca Municipal de
										Aranjuez</option>
									<option value=""BPCM/RBMARA/BMARA1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal �lvarez de Quind�s</option>
									<option value=""BPCM/RBMARG"">&nbsp;&nbsp;&gt;ARGANDA DEL REY. Bibliotecas Municipales
										de Arganda del Rey</option>
									<option value=""BPCM/RBMARG/BMARG2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal La Poveda</option>
									<option value=""BPCM/RBMARG/BMARG1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Pablo Neruda</option>
									<option value=""BPCM/RBMARR"">&nbsp;&nbsp;&gt;ARROYOMOLINOS. Biblioteca Municipal de
										Arroyomolinos</option>
									<option value=""BPCM/RBMARR/BMARR1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal de Arroyomolinos</option>
									<option value=""BPCM/RBMBOA"">&nbsp;&nbsp;&gt;BOADILLA DEL MONTE. Bibliotecas
										Municipales de Boadilla del Monte</option>
									<option value=""BPCM/RBMBOA/BMBOA1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal de Boadilla del Monte</option>
									<option value=""BPCM/RBMBOA/BMBOA2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Jos� Ortega y Gasset</option>
									<option value=""BPCM/RBMBRU"">&nbsp;&nbsp;&gt;BRUNETE. Biblioteca Municipal de Brunete
									</option>
									<option value=""BPCM/RBMBRU/BMBRU1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Dulce Chac�n</option>
									<option value=""BPCM/RBMCBR"">&nbsp;&nbsp;&gt;CABRERA. Biblioteca Municipal de La
										Cabrera</option>
									<option value=""BPCM/RBMCBR/BMCBR1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca del
										Centro Comarcal de Humanidades Cardenal Gonzaga. Sierra Norte</option>
									<option value=""BPCM/RBMCAE"">&nbsp;&nbsp;&gt;CAMARMA DE ESTERUELAS. Biblioteca
										Municipal de Camarma de Esteruelas</option>
									<option value=""BPCM/RBMCAE/BMCAE1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal de Camarma de Esteruelas</option>
									<option value=""BPCM/RBMCHP"">&nbsp;&nbsp;&gt;CHAPINER�A. Biblioteca Municipal de
										Chapiner�a</option>
									<option value=""BPCM/RBMCHP/BMCHP1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal de Chapiner�a</option>
									<option value=""BPCM/RBMCHI"">&nbsp;&nbsp;&gt;CHINCH�N. Biblioteca Municipal de
										Chinch�n</option>
									<option value=""BPCM/RBMCHI/BMCHI1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Petra Ram�rez</option>
									<option value=""BPCM/RBMCIE"">&nbsp;&nbsp;&gt;CIEMPOZUELOS. Biblioteca Municipal de
										Ciempozuelos</option>
									<option value=""BPCM/RBMCIE/BMCIE1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal de Ciempozuelos</option>
									<option value=""BPCM/RBMCOV"">&nbsp;&nbsp;&gt;COLLADO VILLALBA. Biblioteca Municipales
										de Collado Villalba</option>
									<option value=""BPCM/RBMCOV/BMCOV2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Miguel Hern�ndez</option>
									<option value=""BPCM/RBMCOV/BMCOV1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Sancho Panza</option>
									<option value=""BPCM/RBMCVI"">&nbsp;&nbsp;&gt;COLMENAR VIEJO. Bibliotecas Municipales
										de Colmenar Viejo</option>
									<option value=""BPCM/RBMCVI/BMCVI1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Miguel de Cervantes</option>
									<option value=""BPCM/RBMCVI/BMCVI2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Pablo Ruiz Picasso</option>
									<option value=""BPCM/RBMCVI/BMCVI3"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Vargas Llosa</option>
									<option value=""BPCM/RBMCOS"">&nbsp;&nbsp;&gt;COSLADA. Bibliotecas Municipales de
										Coslada</option>
									<option value=""BPCM/RBMCOS/BMCOS1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Central</option>
									<option value=""BPCM/RBMCOS/BMCOS2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal La Jaramilla</option>
									<option value=""BPCM/RBMELE"">&nbsp;&nbsp;&gt;EL ESCORIAL. Biblioteca Municipal de El
										Escorial</option>
									<option value=""BPCM/RBMELE/BMELE1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal de El Escorial</option>
									<option value=""BPCM/RBMELM"">&nbsp;&nbsp;&gt;EL MOLAR. Biblioteca Municipal de El
										Molar</option>
									<option value=""BPCM/RBMELM/BMELM1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Blanca de Igual</option>
									<option value=""BPCM/RBMFSZ"">&nbsp;&nbsp;&gt;FUENTE EL SAZ. Biblioteca Municipal de
										Fuente el Saz de Jarama</option>
									<option value=""BPCM/RBMFSZ/BMFSZ1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal El Pilar</option>
									<option value=""BPCM/RBMFNT"">&nbsp;&nbsp;&gt;FUENTIDUE�A DE TAJO. Biblioteca
										Municipal de Fuentidue�a de Tajo</option>
									<option value=""BPCM/RBMFNT/BMFNT1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Luis Cubero</option>
									<option value=""BPCM/RBMGAL"">&nbsp;&nbsp;&gt;GALAPAGAR. Biblioteca Municipal de
										Galapagar</option>
									<option value=""BPCM/RBMGAL/BMGAL1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Ricardo Le�n</option>
									<option value=""BPCM/RBMGET"">&nbsp;&nbsp;&gt;GETAFE. Red de Bibliotecas Municipales
										de Getafe</option>
									<option value=""BPCM/RBMGET/BMGET5"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Almudena Grandes
									</option>
									<option value=""BPCM/RBMGET/BMGET4"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Carmen Mart�n
										Gaite</option>
									<option value=""BPCM/RBMGET/BMGET1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Jorge Luis Borges
									</option>
									<option value=""BPCM/RBMGET/BMGET3"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Jos� Luis
										Sampedro</option>
									<option value=""BPCM/RBMGET/BMGET2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Ricardo de la
										Vega</option>
									<option value=""BPCM/RBMGRI"">&nbsp;&nbsp;&gt;GRI��N. Biblioteca Municipal de Gri��n
									</option>
									<option value=""BPCM/RBMGRI/BMGRI1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Casa de la Cultura</option>
									<option value=""BPCM/RBMGDR"">&nbsp;&nbsp;&gt;GUADARRAMA. Biblioteca Municipal de
										Guadarrama</option>
									<option value=""BPCM/RBMGDR/BMGDR1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Arcipreste de Hita</option>
									<option value=""BPCM/RBMHUM"">&nbsp;&nbsp;&gt;HUMANES DE MADRID. Biblioteca Municipal
										de Humanes de Madrid</option>
									<option value=""BPCM/RBMHUM/BMHUM1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Lorenzo Silva</option>
									<option value=""BPCM/BPM"">&nbsp;&nbsp;&gt;MADRID. Bibliotecas P�blicas</option>
									<option value=""BPCM/BPM/BCDIU"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;ARGANZUELA. BP P�o
										Baroja</option>
									<option value=""BPCM/BPM/BCDIG"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;BARAJAS. BP Gloria
										Fuertes</option>
									<option value=""BPCM/BPM/BCDIB"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CARABANCHEL. BP Ana
										M� Matute</option>
									<option value=""BPCM/BPM/BCDIM"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CARABANCHEL. BP La
										Chata</option>
									<option value=""BPCM/BPM/BP04"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CARABANCHEL. BP Luis
										Rosales</option>
									<option value=""BPCM/BPM/BCDIX"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CENTRO. BP Benito
										P�rez Gald�s</option>
									<option value=""BPCM/BPM/BCDI4"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CENTRO. BP Iv�n de
										Vargas</option>
									<option value=""BPCM/BPM/BP06"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CENTRO. BP Pedro
										Salinas</option>
									<option value=""BPCM/BPM/BCDI7"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CENTRO. BP Vargas
										LLosa</option>
									<option value=""BPCM/BPM/BCDIZ"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CHAMART�N. BP D�maso
										Alonso</option>
									<option value=""BPCM/BPM/BCDIF"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CHAMART�N. BP
										Francisco Iba�ez</option>
									<option value=""BPCM/BPM/BP05"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CHAMBER�. BP Jos� Luis
										Sampedro</option>
									<option value=""BPCM/BPM/BP17"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CHAMBER�. BP Ruiz Egea
									</option>
									<option value=""BPCM/BPM/BCDIS"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CIUDAD LINEAL. BP
										Ciudad Lineal</option>
									<option value=""BPCM/BPM/BCDID"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CIUDAD LINEAL. BP La
										Elipa</option>
									<option value=""BPCM/BPM/BCDIL"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CIUDAD LINEAL. BP
										Pablo Neruda</option>
									<option value=""BPCM/BPM/BCDIR"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;FUENCARRAL-EL PARDO.
										BP Jos� Saramago</option>
									<option value=""BPCM/BPM/BP08"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;FUENCARRAL-EL PARDO.
										BP Rafael Alberti</option>
									<option value=""BPCM/BPM/BP09"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;HORTALEZA. BP
										Hortaleza</option>
									<option value=""BPCM/BPM/BCDIA"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;HORTALEZA. BP Huerta
										de la Salud</option>
									<option value=""BPCM/BPM/BCDI8"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;HORTALEZA. BP Mar�a
										Lej�rraga</option>
									<option value=""BPCM/BPM/BCDIK"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;LATINA. BP Aluche
									</option>
									<option value=""BPCM/BPM/BCDI3"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;LATINA. BP �ngel
										Gonz�lez</option>
									<option value=""BPCM/BPM/BP10"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;LATINA. BP Antonio
										Mingote</option>
									<option value=""BPCM/BPM/BP02"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;MONCLOA-ARAVACA. BP
										Acu�a</option>
									<option value=""BPCM/BPM/BCDIH"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;MORATALAZ. BP Miguel
										Delibes</option>
									<option value=""BPCM/BPM/BP13"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;MORATALAZ. BP
										Moratalaz</option>
									<option value=""BPCM/BPM/BP19"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;PUENTE DE VALLECAS. BP
										Miguel Hern�ndez</option>
									<option value=""BPCM/BPM/BP14"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;PUENTE DE VALLECAS. BP
										Paco Rabal</option>
									<option value=""BPCM/BPM/BCDIJ"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;PUENTE DE VALLECAS.
										BP Portazgo</option>
									<option value=""BPCM/BPM/BCDIQ"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;PUENTE DE VALLECAS.
										BP Pozo T�o Raimundo</option>
									<option value=""BPCM/BPM/BCDIV"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;PUENTE DE VALLECAS.
										BP Vallecas</option>
									<option value=""BPCM/BPM/BP16"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;RETIRO. BP Elena
										Fort�n</option>
									<option value=""BPCM/BPM/BCDI5"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;RETIRO. BP Eugenio
										Tr�as</option>
									<option value=""BPCM/BPM/BCDIN"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;SALAMANCA. BP
										Buenavista</option>
									<option value=""BPCM/BPM/BCDIC"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;SAN BLAS. BP
										Canillejas</option>
									<option value=""BPCM/BPM/BCDIW"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;SAN BLAS. BP Jos�
										Hierro</option>
									<option value=""BPCM/BPM/BCDIO"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;SAN BLAS. BP San Blas
									</option>
									<option value=""BPCM/BPM/BCDIT"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;TETU�N. BP Mar�a
										Zambrano</option>
									<option value=""BPCM/BPM/BCDI2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;TETU�N. BP V�zquez
										Montalb�n</option>
									<option value=""BPCM/BPM/BCDII"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;USERA. BP Garc�a
										M�rquez</option>
									<option value=""BPCM/BPM/BP18"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;USERA. BP Jos� Hierro
									</option>
									<option value=""BPCM/BPM/BCDIP"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;VIC�LVARO. BP
										Francisco Ayala</option>
									<option value=""BPCM/BPM/BCDIE"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;VIC�LVARO. BP
										Vic�lvaro</option>
									<option value=""BPCM/BPM/BCDIY"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;VILLA DE VALLECAS. BP
										Gerardo Diego</option>
									<option value=""BPCM/BPM/BP20"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;VILLA DE VALLECAS. BP
										Luis Mart�n Santos</option>
									<option value=""BPCM/BPM/BP21"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;VILLAVERDE. BP Mar�a
										Moliner</option>
									<option value=""BPCM/RBMMAJ"">&nbsp;&nbsp;&gt;MAJADAHONDA. Biblioteca Municipal de
										Majadahonda</option>
									<option value=""BPCM/RBMMAJ/BMMAJ1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Francisco Umbral</option>
									<option value=""BPCM/RBMMEC"">&nbsp;&nbsp;&gt;MECO. Biblioteca Municipal de Meco
									</option>
									<option value=""BPCM/RBMMEC/BMMEC1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal de Meco</option>
									<option value=""BPCM/RBMMEJ"">&nbsp;&nbsp;&gt;MEJORADA DEL CAMPO. Biblioteca Municipal
										de Mejorada del Campo</option>
									<option value=""BPCM/RBMMEJ/BMMEJ1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Hans Christian Andersen</option>
									<option value=""BPCM/RBMMRZ"">&nbsp;&nbsp;&gt;MORALZARZAL. Biblioteca Municipal de
										Moralzarzal</option>
									<option value=""BPCM/RBMMRZ/BMMRZ1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Casa Grande</option>
									<option value=""BPCM/RBMMOS"">&nbsp;&nbsp;&gt;M�STOLES. Bibliotecas Municipales
									</option>
									<option value=""BPCM/RBMMOS/BMMOS4"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B. M�stoles
										CALEIDOSCOPIO</option>
									<option value=""BPCM/RBMMOS/BMMOS1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B. M�stoles
										CENTRAL</option>
									<option value=""BPCM/RBMMOS/BMMOS6"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B. M�stoles
										COIMBRA</option>
									<option value=""BPCM/RBMMOS/BMMOS2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B. M�stoles EL
										SOTO</option>
									<option value=""BPCM/RBMMOS/BMMOS3"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B. M�stoles JOAN
										MIR�</option>
									<option value=""BPCM/RBMMOS/BMMOS5"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B. M�stoles
										NORTE-UNIVERSIDAD</option>
									<option value=""BPCM/RBMNAL"">&nbsp;&nbsp;&gt;NAVALCARNERO. Biblioteca Municipal de
										Navalcarnero</option>
									<option value=""BPCM/RBMNAL/BMNAL1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Jos� Mar�a Baus�</option>
									<option value=""BPCM/RBMPAJ"">&nbsp;&nbsp;&gt;PARACUELLOS DE JARAMA. Biblioteca
										Municipal de Paracuellos de Jarama</option>
									<option value=""BPCM/RBMPAJ/BMPAJ1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal de Paracuellos de Jarama</option>
									<option value=""BPCM/RBMPAR"">&nbsp;&nbsp;&gt;PARLA. Bibliotecas Municipales de Parla
									</option>
									<option value=""BPCM/RBMPAR/BMPAR1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Gloria Fuertes</option>
									<option value=""BPCM/RBMPAR/BMPAR2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Isaac Alb�niz</option>
									<option value=""BPCM/RBMPED"">&nbsp;&nbsp;&gt;PEDREZUELA. Biblioteca Municipal
									</option>
									<option value=""BPCM/RBMPED/BMPED1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal de Pedrezuela</option>
									<option value=""BPCM/RBMPNT"">&nbsp;&nbsp;&gt;PINTO. Bibliotecas Municipales de Pinto
									</option>
									<option value=""BPCM/RBMPNT/BMPNT1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Casa de la Cadena</option>
									<option value=""BPCM/RBMPNT/BMPNT2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Javier Lape�a</option>
									<option value=""BPCM/RBMRVM"">&nbsp;&nbsp;&gt;RIVAS VACIAMADRID. Bibliotecas
										Municipales de Rivas Vaciamadrid</option>
									<option value=""BPCM/RBMRVM/BMRVM3"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B.M. Casco
										Antiguo</option>
									<option value=""BPCM/RBMRVM/BMRVM1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B.M. Federico
										Garc�a Lorca</option>
									<option value=""BPCM/RBMRVM/BMRVM4"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B.M. Gloria
										Fuertes</option>
									<option value=""BPCM/RBMRVM/BMRVM2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B.M. Jos�
										Saramago</option>
									<option value=""BPCM/RBMROB"">&nbsp;&nbsp;&gt;ROBLEDO DE CHAVELA. Biblioteca Municipal
										de Robledo de Chavela</option>
									<option value=""BPCM/RBMROB/BMROB1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Antoniorrobles</option>
									<option value=""BPCM/RBMSFH"">&nbsp;&nbsp;&gt;SAN FERNANDO DE HENARES. Bibliotecas
										Municipales de San Fernando de Henares</option>
									<option value=""BPCM/RBMSFH/BMSFH2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Mario Benedetti
									</option>
									<option value=""BPCM/RBMSFH/BMSFH1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Rafael Alberti
									</option>
									<option value=""BPCM/RBMSLE"">&nbsp;&nbsp;&gt;SAN LORENZO DE EL ESCORIAL. Biblioteca
										Municipal de San Lorenzo de El Escorial</option>
									<option value=""BPCM/RBMSLE/BMSLE1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Pedro Antonio de Alarc�n</option>
									<option value=""BPCM/RBMSMV"">&nbsp;&nbsp;&gt;SAN MART�N DE LA VEGA. Biblioteca
										Municipal de San Mart�n de la Vega</option>
									<option value=""BPCM/RBMSMV/BMSMV1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Dos de Mayo</option>
									<option value=""BPCM/RBMSMI"">&nbsp;&nbsp;&gt;SAN MART�N DE VALDEIGLESIAS. Biblioteca
										Municipal de San Mart�n de Valdeiglesias</option>
									<option value=""BPCM/RBMSMI/BMSMI1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Miguel Hern�ndez</option>
									<option value=""BPCM/RBMSSR"">&nbsp;&nbsp;&gt;SAN SEBASTI�N DE LOS REYES. Bibliotecas
										Municipales de S. Sebasti�n de los Reyes</option>
									<option value=""BPCM/RBMSSR/BMSSR2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Claudio Rodr�guez</option>
									<option value=""BPCM/RBMSSR/BMSSR1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Marcos Ana</option>
									<option value=""BPCM/RBMSSR/BMSSR3"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Plaza de la Iglesia</option>
									<option value=""BPCM/RBMSEV"">&nbsp;&nbsp;&gt;SEVILLA LA NUEVA. Biblioteca Municipal
										de Sevilla la Nueva</option>
									<option value=""BPCM/RBMSEV/BMSEV1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Jos� �ngel Ma�as</option>
									<option value=""BPCM/RBMSOT"">&nbsp;&nbsp;&gt;SOTO DEL REAL. Biblioteca Municipal de
										Soto de Real</option>
									<option value=""BPCM/RBMSOT/BMSOT1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Pedro de Lorenzo</option>
									<option value=""BPCM/RBMTAL"">&nbsp;&nbsp;&gt;TALAMANCA DE JARAMA. Biblioteca
										Municipal de Talamanca de Jarama</option>
									<option value=""BPCM/RBMTAL/BMTAL1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal de Talamanca de Jarama</option>
									<option value=""BPCM/RBMTOR"">&nbsp;&nbsp;&gt;TORREJ�N DE ARDOZ. Bibliotecas
										Municipales de Torrej�n de Ardoz</option>
									<option value=""BPCM/RBMTOR/BMTOR3"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Enrique Tierno Galv�n</option>
									<option value=""BPCM/RBMTOR/BMTOR2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Federico Garc�a-Lorca</option>
									<option value=""BPCM/RBMTOR/BMTOR1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Gabriel Celaya</option>
									<option value=""BPCM/RBMTOR/BMTOR4"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca ""La
										Isla Misteriosa""</option>
									<option value=""BPCM/RBMTRC"">&nbsp;&nbsp;&gt;TORREJ�N DE LA CALZADA. Biblioteca
										Municipal</option>
									<option value=""BPCM/RBMTRC/BMTRC1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Mar�a Moliner</option>
									<option value=""BPCM/RBMTRG"">&nbsp;&nbsp;&gt;TORRELAGUNA. Biblioteca Municipal
									</option>
									<option value=""BPCM/RBMTRG/BMTRG1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Juan de Mena</option>
									<option value=""BPCM/RBMTRL"">&nbsp;&nbsp;&gt;TORRELODONES. Bibliotecas Municipales de
										Torrelodones</option>
									<option value=""BPCM/RBMTRL/BMTRL2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Casa de la Cultura</option>
									<option value=""BPCM/RBMTRL/BMTRL1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Jos� de Vicente Mu�oz</option>
									<option value=""BPCM/RBMTRE"">&nbsp;&nbsp;&gt;TRES CANTOS. Bibliotecas Municipales
										Tres Cantos</option>
									<option value=""BPCM/RBMTRE/BMTRE2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Fundaci�n Caja Madrid</option>
									<option value=""BPCM/RBMTRE/BMTRE1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Lope de Vega</option>
									<option value=""BPCM/RBMVDM"">&nbsp;&nbsp;&gt;VALDEMORILLO. Biblioteca Municipal de
										Valdemorillo</option>
									<option value=""BPCM/RBMVDM/BMVDM1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Mar�a Giralt</option>
									<option value=""BPCM/RBMVDE"">&nbsp;&nbsp;&gt;VALDEMORO. Bibliotecas Municipales de
										Valdemoro</option>
									<option value=""BPCM/RBMVDE/BMVDE1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Ana Mar�a Matute</option>
									<option value=""BPCM/RBMVDE/BMVDE3"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Centro de la Estaci�n</option>
									<option value=""BPCM/RBMVDE/BMVDE2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Juan Prado</option>
									<option value=""BPCM/RBMVEL"">&nbsp;&nbsp;&gt;VELILLA DE SAN ANTONIO. Biblioteca
										Municipal de Velilla de San Antonio</option>
									<option value=""BPCM/RBMVEL/BMVEL1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Mar�a Moliner</option>
									<option value=""BPCM/RBMVIP"">&nbsp;&nbsp;&gt;VILLA DEL PRADO. Biblioteca Municipal de
										Villa del Prado</option>
									<option value=""BPCM/RBMVIP/BMVIP1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Alfonso Uss�a de Villa del Prado</option>
									<option value=""BPCM/RBMVIB"">&nbsp;&nbsp;&gt;VILLALBILLA. Bibliotecas Municipales de
										Villalbilla</option>
									<option value=""BPCM/RBMVIB/BMVIB1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal El Sauce</option>
									<option value=""BPCM/RBMVIB/BMVIB2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Centro de Lectura
									</option>
									<option value=""BPCM/RBMVNV"">&nbsp;&nbsp;&gt;VILLANUEVA DE LA CA�ADA. Biblioteca
										Municipal de Villanueva de la Ca�ada</option>
									<option value=""BPCM/RBMVNV/BMVNV1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;VILLANUEVA DE LA
										CA�ADA. Biblioteca Municipal Fernando L�zaro Carreter</option>
									<option value=""BPCM/RBMVIL"">&nbsp;&nbsp;&gt;VILLANUEVA DEL PARDILLO. Biblioteca
										Municipal de Villanueva del Pardillo</option>
									<option value=""BPCM/RBMVIL/BMVIL1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal de Villanueva del Pardillo</option>
									<option value=""BPCM/RBMVVO"">&nbsp;&nbsp;&gt;VILLAVICIOSA DE OD�N. Biblioteca
										Municipal de Villaviciosa de Od�n</option>
									<option value=""BPCM/RBMVVO/BMVVO1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca
										Municipal Luis de G�ngora</option>
								</select>

								<div id=""biblioFake"">
									<p>
										<span>En:</span>
										<a id=""biblioButton"" href=""#"">
											<span id=""biblioSelec""></span>
											<i class=""fa angle-down fa-border"">&#xf107;</i>
										</a>
									</p>
									<div id=""biblioList"">
										<ul id=""grupo""></ul>
										<ul id=""biblio""></ul>
										<ul id=""sucu""></ul>
										<p id=""pInput"">
											<span>Filtrar por:</span>
											<input placeholder=""Municipio"" autocomplete=""off"" id=""searchInp"" type=""text""
												title=""Municipio"" alt=""Municipio"" />
											<input placeholder=""Biblioteca"" autocomplete=""off"" id=""searchInp1""
												type=""text"" title=""Biblioteca"" alt=""Biblioteca"" />
											<a id=""clearFilter"" href=""#"" title=""Limpiar"" alt=""Limpiar""><i
													class=""fa imes-circle"">&#xf057;</i></a>
										</p>
									</div>
								</div>
								<script>
									fakeMenu();
								</script>
							</div>
						</form><br />
						<form action=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1"" method=""post""
							id=""abnophist"" name=""abnophist"">
							<input type=""hidden"" name=""ACC"" value=""137"" />
							<div class=""breakp subcat"">
								<label for=""xshist"">Buscando</label>
								<select id=""xshist"" name=""xshist"" onchange=""AbnChgHist();"">
									<option value=""1"">Cualquier campo: coco/</option>
								</select>
								&nbsp;<strong>en&nbsp;Todas las bibliotecas</strong>
								<noscript><input type=""submit"" class=""butt_send"" value=""Enviar"" /></noscript>
							</div>
						</form><br />
						<div class=""levelface"">
							<span>B�squeda facetada</span>

							<img src=""/biblio_publicas/imag/arrow_face.gif"" alt="" "" />&nbsp;</i><a
								href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;xsqf01=(coco)&amp;xsface=on&amp;etapaFace=0&amp;fieldFace=&amp;xindbt="">(coco)</a>&nbsp;

						</div>
						<br /><br />
						<div class=""reglist"">
							<div class=""reglistl"">
								<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=264""
									onclick=""AbnOpacCheckAll();return false;"" class=""butt_send""><i
										class=""fa check-square"" aria-hidden=""true"">&#xf14a;</i><span>Marcar
										todos</span></a>
								<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=268""
									onclick=""AbnOpacCheckList();return false;"" class=""butt_send ""><i
										class=""fa check-square-o"" aria-hidden=""true"">&#xf046;</i><span>Marcar
										b�squeda</span></a>
								<div id=""cbubble"" class=""bubble ""><a href=""#""
										onclick=""this.parentNode.className='bubble';return false;"" class=""bb""><span
											class=""tt""><span class=""tp""></span><span id=""md"" class=""md""></span><span
												class=""bt""></span></span></a></div>
								<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=120""
									class=""butt_send""><i class=""fa search"" aria-hidden=""true"">&#xf002;</i><span>Volver a
										Buscar</span></a>

							</div>
							<div class=""reglistr"">

								<div class=""toggle-picker toggle-list"">
									<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=163&amp;DOC=1&amp;LISTDSI=1&amp;LISTMOSAIC=-1""
										onclick=""AbnOpacListMosaic(-1);return false;"" title=""Vista de lista""></a>
									<div class=""picker layout-picker"">
										<div class=""picker-inner picker-last-col""></div>
										<div class=""picker-inner picker-last-col""></div>
										<div class=""picker-inner picker-last-row picker-last-col""></div>
									</div>
								</div>
								<div class=""toggle-picker toggle-mosaic"">
									<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=163&amp;DOC=1&amp;LISTDSI=1&amp;LISTMOSAIC=1""
										onclick=""AbnOpacListMosaic(1);return false;"" title=""Vista de im�genes""></a>
									<div class=""picker image-layout-picker"">
										<div class=""picker-inner""></div>
										<div class=""picker-inner picker-last-col""></div>
										<div class=""picker-inner picker-last-row""></div>
										<div class=""picker-inner picker-last-row picker-last-col""></div>
									</div>
								</div>
								<h3 class=""recordsetlist"">Registros <strong>1/10</strong> de <strong>873</strong></h3>
							</div>
							<div class=""empty""></div>
						</div>
						<div class=""regdoc"">

							<span class=""acti"">1</span><span class='barr'>&nbsp;|&nbsp;</span><a
								href='/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=161&amp;DOC=11'
								class='noacti' title=""Registro 11 / 20""
								onclick='AbnOpacListDoc(""11"");return false;'>2</a><span
								class='barr'>&nbsp;|&nbsp;</span><a
								href='/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=161&amp;DOC=21'
								class='noacti' title=""Registro 21 / 30""
								onclick='AbnOpacListDoc(""21"");return false;'>3</a><span
								class='barr'>&nbsp;|&nbsp;</span><a
								href='/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=161&amp;DOC=31'
								class='noacti' title=""Registro 31 / 40""
								onclick='AbnOpacListDoc(""31"");return false;'>4</a><span
								class='barr'>&nbsp;|&nbsp;</span><a
								href='/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=161&amp;DOC=41'
								class='noacti' title=""Registro 41 / 50""
								onclick='AbnOpacListDoc(""41"");return false;'>5</a>

							<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=161&amp;DOC=11""
								onclick=""AbnOpacListDoc(11);return false;"" title=""Siguiente"" class=""noacti"">&#187;</a>

						</div>
						<br />
						<div class=""busqface"">
							<div class=""faceres"">
								<div class=""dvreg detailreg face"">

									<div class=""dvdoc"">
										<div class=""docleft"">

											<script
												type=""text/javascript"">/*<![CDATA[*/writeTag('<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=165&amp;DOC=1&amp;xsface=on"" class=""cover"" title=""Cubierta""><img src=""/biblio_publicas/imag/loading.gif"" url=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=299&amp;MLKOB=506679853737"" alt=""Cubierta (DOC1)"" onload=""putUrl(this)""/></a>')/*]]>*/</script>
											<noscript><a
													href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=165&amp;DOC=1&amp;xsface=on""
													class=""cover"" title=""Cubierta""><img
														src=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=299&amp;MLKOB=506679853737""
														alt=""Cubierta (DOC1)"" /></a></noscript>

										</div>
										<div class=""docright"">
											<span class=""coverList"">
												<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=266&amp;DOC=1""
													onclick=""AbnOpacCheck(1,this);return false;""><img
														src=""/biblio_publicas/imag/check0.gif"" name=""check""
														alt=""Marcar"" /></a>&nbsp;<img
													src='/biblio_publicas/imag/mater01.gif' title=""Monograf�as""
													alt=""Monograf�as"" /><strong class=""dvauth"">Dur�, Marga</strong>
												<span class=""dvocc"" title=""3 T�tulos relacionados"">3 ocur.</span>
												<p><a href=""?ACC=165&amp;DOC=1""
														onclick=""AbnOpacDoc(1);return false;"">Mujeres poderosas : que te
														inspiran para plantarle cara a la vida / Marga Dur� ;
														ilustraciones de Coco Escribano&nbsp;(2019)</a></p>
												<p class=""noMosaic""><strong>Edici�n:</strong> 1� ed.</p>
												<p><strong class=""noMosaic"">Publicaci�n:</strong> Barcelona : Grijalbo,
													2019</p>
												<p class=""noMosaic""><strong>Descripci�n f�sica:</strong> 207 p. : il.
													col. ; 24 cm</p>

												<p class=""noMosaic""><strong>ISBN:</strong> 978-84-17338-30-5</p>

												<p class=""noMosaic""><strong>Autores/Autoras:</strong>
													<br />&nbsp;Escribano, Coco (1984-)</p>



												<input type=""hidden"" class=""wn856""
													value=""http://madrid.digitalbooks.pro/9788417752033 "" />


											</span>
										</div>
									</div>

									<div class=""dvdoc"">
										<div class=""docleft"">

											<script
												type=""text/javascript"">/*<![CDATA[*/writeTag('<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=165&amp;DOC=2&amp;xsface=on"" class=""cover"" title=""Cubierta""><img src=""/biblio_publicas/imag/loading.gif"" url=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=299&amp;MLKOB=593655664848"" alt=""Cubierta (DOC2)"" onload=""putUrl(this)""/></a>')/*]]>*/</script>
											<noscript><a
													href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=165&amp;DOC=2&amp;xsface=on""
													class=""cover"" title=""Cubierta""><img
														src=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=299&amp;MLKOB=593655664848""
														alt=""Cubierta (DOC2)"" /></a></noscript>

										</div>
										<div class=""docright"">
											<span class=""coverList"">
												<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=266&amp;DOC=2""
													onclick=""AbnOpacCheck(2,this);return false;""><img
														src=""/biblio_publicas/imag/check0.gif"" name=""check""
														alt=""Marcar"" /></a>&nbsp;<img
													src='/biblio_publicas/imag/mater01.gif' title=""Monograf�as""
													alt=""Monograf�as"" /><strong class=""dvauth"">Scaraffia, Giuseppe
													(1950-)</strong>
												<span class=""dvocc"" title=""1 T�tulos relacionados"">1 ocur.</span>
												<p><a href=""?ACC=165&amp;DOC=2"" onclick=""AbnOpacDoc(2);return false;"">La
														novela de la Costa Azul / Giuseppe Scaraffia ; traducci�n de
														Francisco Campillo&nbsp;(2019)</a></p>
												<p class=""noMosaic""><strong>Edici�n:</strong> 1� ed.</p>
												<p><strong class=""noMosaic"">Publicaci�n:</strong> C�ceres : Perif�rica,
													2019</p>
												<p class=""noMosaic""><strong>Descripci�n f�sica:</strong> 429 p. ; 21 cm
												</p>

												<p class=""noMosaic""><strong>ISBN:</strong> 9788416291823</p>




											</span>
										</div>
									</div>

									<div class=""dvdoc"">
										<div class=""docleft"">
											<!-- Portadas externas -->
											<script
												type=""text/javascript"">/*<![CDATA[*/writeTag('<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=165&amp;DOC=3&amp;xsface=on"" class=""coverAlternate"" title=""OpenLibrary""><img src=""/biblio_publicas/imag/loading.gif"" url=""http://covers.openlibrary.org/b/isbn/nofound-M.jpg"" alt=""OpenLibrary (DOC3)"" onload=""putUrl(this)""/></a>')/*]]>*/</script>
											<noscript><a
													href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=165&amp;DOC=3&amp;xsface=on""
													class=""coverAlternate"" title=""OpenLibrary""><img
														src=""http://covers.openlibrary.org/b/isbn/nofound-M.jpg""
														alt=""OpenLibrary (DOC3)"" /></a></noscript>


										</div>
										<div class=""docright"">
											<span class=""coverList"">
												<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=266&amp;DOC=3""
													onclick=""AbnOpacCheck(3,this);return false;""><img
														src=""/biblio_publicas/imag/check0.gif"" name=""check""
														alt=""Marcar"" /></a>&nbsp;<img
													src='/biblio_publicas/imag/mater07.gif'
													title=""Videograbaciones (DVD)""
													alt=""Videograbaciones (DVD)"" /><strong class=""dvauth"">The cocoanuts
													(Pel�cula cinematogr�fica)</strong>
												<span class=""dvocc"" title=""2 T�tulos relacionados"">2 ocur.</span>
												<p><a href=""?ACC=165&amp;DOC=3""
														onclick=""AbnOpacDoc(3);return false;"">Los cuatro cocos = The
														cocoanuts / directed by Robert Florey and Joseph Santley ;
														screen adaptation by Morrie Ryskind&nbsp;(2019)</a></p>
												<p><strong class=""noMosaic"">Publicaci�n:</strong> Madrid : distribuido
													por Sony Pictures Entertainment Iberia, D.L. 2019</p>
												<p class=""noMosaic""><strong>Descripci�n f�sica:</strong> 1 Blu-ray (ca.
													93 min.) : son. bl. y n.</p>


												<p class=""noMosaic""><strong>Autores/Autoras:</strong>
													<br />&nbsp;Florey, Robert, director de cine<br />&nbsp;Santley,
													Joseph, director de cine<br />&nbsp;Marx, Groucho (1891-1977),
													actor<br />&nbsp;Marx, Harpo (1888-1964)<br />&nbsp;Marx, Chico
													(1887-1961), actor</p>



											</span>
										</div>
									</div>

									<div class=""dvdoc"">
										<div class=""docleft"">
											<!-- Portadas externas -->
											<script
												type=""text/javascript"">/*<![CDATA[*/writeTag('<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=165&amp;DOC=4&amp;xsface=on"" class=""coverAlternate"" title=""OpenLibrary""><img src=""/biblio_publicas/imag/loading.gif"" url=""http://covers.openlibrary.org/b/isbn/8417708421-M.jpg"" alt=""OpenLibrary (DOC4)"" onload=""putUrl(this)""/></a>')/*]]>*/</script>
											<noscript><a
													href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=165&amp;DOC=4&amp;xsface=on""
													class=""coverAlternate"" title=""OpenLibrary""><img
														src=""http://covers.openlibrary.org/b/isbn/8417708421-M.jpg""
														alt=""OpenLibrary (DOC4)"" /></a></noscript>


										</div>
										<div class=""docright"">
											<span class=""coverList"">
												<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=266&amp;DOC=4""
													onclick=""AbnOpacCheck(4,this);return false;""><img
														src=""/biblio_publicas/imag/check0.gif"" name=""check""
														alt=""Marcar"" /></a>&nbsp;<img
													src='/biblio_publicas/imag/mater01.gif' title=""Monograf�as""
													alt=""Monograf�as"" /><strong class=""dvauth"">Marly, Michelle
													(1956-)</strong>
												<span class=""dvocc"" title=""3 T�tulos relacionados"">3 ocur.</span>
												<p><a href=""?ACC=165&amp;DOC=4""
														onclick=""AbnOpacDoc(4);return false;"">Mademoiselle Coco y la
														pasi�n por el n�mero 5 / Michelle Marly; traducci�n Lidia
														�lvarez Grifoll&nbsp;(2019)</a></p>
												<p><strong class=""noMosaic"">Publicaci�n:</strong> Maeva, 2019</p>
												<p class=""noMosaic""><strong>Descripci�n f�sica:</strong> 351 p. ; 23 cm
												</p>

												<p class=""noMosaic""><strong>ISBN:</strong> 978-84-17708-42-9</p>




												<input type=""hidden"" class=""wn856""
													value=""https://madrid.ebiblio.es/opac/?query=9788417708535 "" />


											</span>
										</div>
									</div>

									<div class=""dvdoc"">
										<div class=""docleft"">
											<!-- Portadas externas -->
											<script
												type=""text/javascript"">/*<![CDATA[*/writeTag('<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=165&amp;DOC=5&amp;xsface=on"" class=""coverAlternate"" title=""OpenLibrary""><img src=""/biblio_publicas/imag/loading.gif"" url=""http://covers.openlibrary.org/b/isbn/nofound-M.jpg"" alt=""OpenLibrary (DOC5)"" onload=""putUrl(this)""/></a>')/*]]>*/</script>
											<noscript><a
													href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=165&amp;DOC=5&amp;xsface=on""
													class=""coverAlternate"" title=""OpenLibrary""><img
														src=""http://covers.openlibrary.org/b/isbn/nofound-M.jpg""
														alt=""OpenLibrary (DOC5)"" /></a></noscript>


										</div>
										<div class=""docright"">
											<span class=""coverList"">
												<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=266&amp;DOC=5""
													onclick=""AbnOpacCheck(5,this);return false;""><img
														src=""/biblio_publicas/imag/check0.gif"" name=""check""
														alt=""Marcar"" /></a>&nbsp;<img
													src='/biblio_publicas/imag/mater07.gif'
													title=""Videograbaciones (DVD)"" alt=""Videograbaciones (DVD)"" />&nbsp;
												<span class=""dvocc"" title=""2 T�tulos relacionados"">2 ocur.</span>
												<p><a href=""?ACC=165&amp;DOC=5""
														onclick=""AbnOpacDoc(5);return false;"">Los hermanos Marx :
														pel�culas de la gran pantalla&nbsp;(2019)</a></p>
												<p><strong class=""noMosaic"">Publicaci�n:</strong> Madrid : distribuido
													por Sony Pictures Home Entertainment, D.L. 2019</p>
												<p class=""noMosaic""><strong>Descripci�n f�sica:</strong> 5 Blu-ray (ca.
													97, 93, 69, 67, 78 min) : son., bl. y n. + 1 funda</p>


												<p class=""noMosaic""><strong>Autores/Autoras:</strong>
													<br />&nbsp;Santley, Joseph, director de cine<br />&nbsp;Heerman,
													Victor (1893-1977), director de cine<br />&nbsp;McLeod, Norman Z.
													(1898-1964), director de cine<br />&nbsp;McCarey, Leo (1898-1969),
													director de cine</p>
												<p class=""noMosaic""><strong>Entidades:</strong> <br />&nbsp;Marx
													Brothers</p>
												<p class=""noMosaic""><strong>T�tulos Uniformes:</strong> <br />&nbsp;The
													cocoanuts (Pel�cula cinematogr�fica)<br />&nbsp;Animal crackers
													(Pel�cula cinematogr�fica)<br />&nbsp;Monkey business (Pel�cula
													cinematogr�fica)<br />&nbsp;Horse feathers (Pel�cula
													cinematogr�fica)<br />&nbsp;Duck soup (Pel�cula cinematogr�fica)</p>



											</span>
										</div>
									</div>

									<div class=""dvdoc"">
										<div class=""docleft"">
											<!-- Portadas externas -->
											<script
												type=""text/javascript"">/*<![CDATA[*/writeTag('<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=165&amp;DOC=6&amp;xsface=on"" class=""coverAlternate"" title=""OpenLibrary""><img src=""/biblio_publicas/imag/loading.gif"" url=""http://covers.openlibrary.org/b/isbn/nofound-M.jpg"" alt=""OpenLibrary (DOC6)"" onload=""putUrl(this)""/></a>')/*]]>*/</script>
											<noscript><a
													href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=165&amp;DOC=6&amp;xsface=on""
													class=""coverAlternate"" title=""OpenLibrary""><img
														src=""http://covers.openlibrary.org/b/isbn/nofound-M.jpg""
														alt=""OpenLibrary (DOC6)"" /></a></noscript>


										</div>
										<div class=""docright"">
											<span class=""coverList"">
												<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=266&amp;DOC=6""
													onclick=""AbnOpacCheck(6,this);return false;""><img
														src=""/biblio_publicas/imag/check0.gif"" name=""check""
														alt=""Marcar"" /></a>&nbsp;<img
													src='/biblio_publicas/imag/mater03.gif'
													title=""Registros sonoros (CD)""
													alt=""Registros sonoros (CD)"" /><strong class=""dvauth"">Williams,
													Robbie</strong>
												<span class=""dvocc"" title=""2 T�tulos relacionados"">2 ocur.</span>
												<p><a href=""?ACC=165&amp;DOC=6""
														onclick=""AbnOpacDoc(6);return false;"">The Christmas
														present&nbsp;(2019)</a></p>
												<p><strong class=""noMosaic"">Publicaci�n:</strong> G�tersloh (Alemania) :
													Sony Music Entertainment, 2019</p>
												<p class=""noMosaic""><strong>Descripci�n f�sica:</strong> 2 CD-Audio + 1
													folleto ([12] p.)</p>





											</span>
										</div>
									</div>

									<div class=""dvdoc"">
										<div class=""docleft"">

											<script
												type=""text/javascript"">/*<![CDATA[*/writeTag('<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=165&amp;DOC=7&amp;xsface=on"" class=""cover"" title=""Cubierta""><img src=""/biblio_publicas/imag/loading.gif"" url=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=299&amp;MLKOB=677770595757"" alt=""Cubierta (DOC7)"" onload=""putUrl(this)""/></a>')/*]]>*/</script>
											<noscript><a
													href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=165&amp;DOC=7&amp;xsface=on""
													class=""cover"" title=""Cubierta""><img
														src=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=299&amp;MLKOB=677770595757""
														alt=""Cubierta (DOC7)"" /></a></noscript>

										</div>
										<div class=""docright"">
											<span class=""coverList"">
												<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=266&amp;DOC=7""
													onclick=""AbnOpacCheck(7,this);return false;""><img
														src=""/biblio_publicas/imag/check0.gif"" name=""check""
														alt=""Marcar"" /></a>&nbsp;<img
													src='/biblio_publicas/imag/mater01.gif' title=""Monograf�as""
													alt=""Monograf�as"" /><strong class=""dvauth"">Oro, Bego�a</strong>
												<span class=""dvocc"" title=""2 T�tulos relacionados"">2 ocur.</span>
												<p><a href=""?ACC=165&amp;DOC=7"" onclick=""AbnOpacDoc(7);return false;"">Un
														monstruo en la cocina / Bego�a Oro ; [ilustraciones, Ester
														Garc�a]&nbsp;(2019)</a></p>
												<p><strong class=""noMosaic"">Publicaci�n:</strong> Barcelona : Molino,
													2019</p>
												<p class=""noMosaic""><strong>Descripci�n f�sica:</strong> 230 p. : il. ;
													21 cm</p>

												<p class=""noMosaic""><strong>ISBN:</strong> 978-84-272-1675-4</p>




											</span>
										</div>
									</div>

									<div class=""dvdoc"">
										<div class=""docleft"">
											<!-- Portadas externas -->
											<script
												type=""text/javascript"">/*<![CDATA[*/writeTag('<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=165&amp;DOC=8&amp;xsface=on"" class=""coverAlternate"" title=""OpenLibrary""><img src=""/biblio_publicas/imag/loading.gif"" url=""http://covers.openlibrary.org/b/isbn/846623649X-M.jpg"" alt=""OpenLibrary (DOC8)"" onload=""putUrl(this)""/></a>')/*]]>*/</script>
											<noscript><a
													href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=165&amp;DOC=8&amp;xsface=on""
													class=""coverAlternate"" title=""OpenLibrary""><img
														src=""http://covers.openlibrary.org/b/isbn/846623649X-M.jpg""
														alt=""OpenLibrary (DOC8)"" /></a></noscript>


										</div>
										<div class=""docright"">
											<span class=""coverList"">
												<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=266&amp;DOC=8""
													onclick=""AbnOpacCheck(8,this);return false;""><img
														src=""/biblio_publicas/imag/check0.gif"" name=""check""
														alt=""Marcar"" /></a>&nbsp;<img
													src='/biblio_publicas/imag/mater01.gif' title=""Monograf�as""
													alt=""Monograf�as"" /><strong class=""dvauth"">Ma�eru, Mar�a
													(1971-)</strong>
												<span class=""dvocc"" title=""2 T�tulos relacionados"">2 ocur.</span>
												<p><a href=""?ACC=165&amp;DOC=8""
														onclick=""AbnOpacDoc(8);return false;"">Coco est� feliz / Mar�a
														Ma�eru ; [ilustraci�n, Vanesa Bertolini]&nbsp;(2018)</a></p>
												<p><strong class=""noMosaic"">Publicaci�n:</strong> Alcobendas, Madrid :
													Libsa, cop. 2018</p>
												<p class=""noMosaic""><strong>Descripci�n f�sica:</strong> [20] p. :
													principalmente il. col. ; 15 x 15 cm</p>

												<p class=""noMosaic""><strong>ISBN:</strong> 978-84-662-3649-2</p>

												<p class=""noMosaic""><strong>Autores/Autoras:</strong>
													<br />&nbsp;Bertolini, Vanesa, dibujante</p>



											</span>
										</div>
									</div>

									<div class=""dvdoc"">
										<div class=""docleft"">

											<script
												type=""text/javascript"">/*<![CDATA[*/writeTag('<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=165&amp;DOC=9&amp;xsface=on"" class=""cover"" title=""Cubierta""><img src=""/biblio_publicas/imag/loading.gif"" url=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=299&amp;MLKOB=292426663535"" alt=""Cubierta (DOC9)"" onload=""putUrl(this)""/></a>')/*]]>*/</script>
											<noscript><a
													href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=165&amp;DOC=9&amp;xsface=on""
													class=""cover"" title=""Cubierta""><img
														src=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=299&amp;MLKOB=292426663535""
														alt=""Cubierta (DOC9)"" /></a></noscript>

										</div>
										<div class=""docright"">
											<span class=""coverList"">
												<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=266&amp;DOC=9""
													onclick=""AbnOpacCheck(9,this);return false;""><img
														src=""/biblio_publicas/imag/check0.gif"" name=""check""
														alt=""Marcar"" /></a>&nbsp;<img
													src='/biblio_publicas/imag/mater01.gif' title=""Monograf�as""
													alt=""Monograf�as"" /><strong class=""dvauth"">Pradas, N�ria
													(1954-)</strong>
												<span class=""dvocc"" title=""1 T�tulos relacionados"">1 ocur.</span>
												<p><a href=""?ACC=165&amp;DOC=9"" onclick=""AbnOpacDoc(9);return false;"">El
														aroma del tiempo / N�ria Pradas&nbsp;(2018)</a></p>
												<p class=""noMosaic""><strong>Edici�n:</strong> 1� ed.</p>
												<p><strong class=""noMosaic"">Publicaci�n:</strong> Barcelona : Suma, 2018
												</p>
												<p class=""noMosaic""><strong>Descripci�n f�sica:</strong> 507 p. ; 23 cm
												</p>

												<p class=""noMosaic""><strong>ISBN:</strong> 978-84-9129-213-5</p>




												<input type=""hidden"" class=""wn856""
													value=""http://madrid.digitalbooks.pro/9788491292562 "" />


												<input type=""hidden"" class=""wn856""
													value=""http://madrid.ebiblio.es/opac/?query=9788491292562 "" />


											</span>
										</div>
									</div>

									<div class=""dvdoc"">
										<div class=""docleft"">

											<script
												type=""text/javascript"">/*<![CDATA[*/writeTag('<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=165&amp;DOC=10&amp;xsface=on"" class=""cover"" title=""Cubierta""><img src=""/biblio_publicas/imag/loading.gif"" url=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=299&amp;MLKOB=326413582222"" alt=""Cubierta (DOC10)"" onload=""putUrl(this)""/></a>')/*]]>*/</script>
											<noscript><a
													href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=165&amp;DOC=10&amp;xsface=on""
													class=""cover"" title=""Cubierta""><img
														src=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=299&amp;MLKOB=326413582222""
														alt=""Cubierta (DOC10)"" /></a></noscript>

										</div>
										<div class=""docright"">
											<span class=""coverList"">
												<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=266&amp;DOC=10""
													onclick=""AbnOpacCheck(10,this);return false;""><img
														src=""/biblio_publicas/imag/check0.gif"" name=""check""
														alt=""Marcar"" /></a>&nbsp;<img
													src='/biblio_publicas/imag/mater01.gif' title=""Monograf�as""
													alt=""Monograf�as"" /><strong class=""dvauth"">Hess, Megan</strong>
												<span class=""dvocc"" title=""7 T�tulos relacionados"">7 ocur.</span>
												<p><a href=""?ACC=165&amp;DOC=10""
														onclick=""AbnOpacDoc(10);return false;"">Coco Chanel : la
														revoluci�n de la elegancia / Megan Hess ; [traducci�n, Marina
														Mena Guardabrazo]&nbsp;(2018)</a></p>
												<p class=""noMosaic""><strong>Edici�n:</strong> 1� ed.</p>
												<p><strong class=""noMosaic"">Publicaci�n:</strong> Barcelona : Lunwerg,
													2018</p>
												<p class=""noMosaic""><strong>Descripci�n f�sica:</strong> 207 p. :
													principalmente il. b. y n. ; 23 cm</p>

												<p class=""noMosaic""><strong>ISBN:</strong> 978-84-16890-44-6</p>




											</span>
										</div>
									</div>

									<div class=""empty""></div>
								</div>
							</div>
							<div class=""newface"">
								<ul id=""tablist"">
									<li class=""tabsel""><a href=""#tagface""
											onclick=""activateTab(this.parentNode,'tabface','tabdesc');return false;""><i
												class=""fa filter"" aria-hidden=""true"">&#xf0b0;</i><span>Refinar
												por</span></a></li>
									<li><a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=131&amp;CLV=1&amp;xsface=on#tagdesc""
											onclick=""AbnOpacAuto(this);return false;""><i class=""fa search""
												aria-hidden=""true"">&#xf00e;</i><span>Descubrir</span></a></li>
								</ul>
								<div id=""tabcontent"">
									<div id=""tabface""><a name=""tagface""></a>
										<div class=""contentTag"">
											<div class=""facetit nborder"">

												<div>Autor/Autora <a class=""T100,T110,T111"" name=""next-face0""
														href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=131&amp;NEXTFACE=1&amp;fieldFace=T100,T110,T111""
														onclick=""AbnOpacNextFace(this);return false;""
														style=""display:none"">&#187; M�s</a></div>
												<ul class=""T100,T110,T111-ul"">

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Geis, Patricia&quot;.T100,T110,T111.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=T100,T110,T111"">Geis,
															Patricia<em>(7)</em></a></li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Valero, Coco&quot;.T100,T110,T111.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=T100,T110,T111"">Valero,
															Coco<em>(6)</em></a></li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Coco, Emilio&quot;.T100,T110,T111.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=T100,T110,T111"">Coco,
															Emilio<em>(3)</em></a></li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Elliott, Dan&quot;.T100,T110,T111.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=T100,T110,T111"">Elliott,
															Dan<em>(3)</em></a></li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Tison, Annette&quot;.T100,T110,T111.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=T100,T110,T111"">Tison,
															Annette<em>(3)</em></a></li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Doplicher, Fabio&quot;.T100,T110,T111.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=T100,T110,T111"">Doplicher,
															Fabio<em>(2)</em></a></li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Wei, Hui&quot;.T100,T110,T111.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=T100,T110,T111"">Wei,
															Hui<em>(2)</em></a></li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Lentini, Javier&quot;.T100,T110,T111.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=T100,T110,T111"">Lentini,
															Javier<em>(2)</em></a></li>

												</ul>

												<div>T�tulo <a class=""T245"" name=""next-face0""
														href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=131&amp;NEXTFACE=1&amp;fieldFace=T245""
														onclick=""AbnOpacNextFace(this);return false;""
														style=""display:none"">&#187; M�s</a></div>
												<ul class=""T245-ul"">

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Barbapap�.&quot;.T245.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=T245"">Barbapap�.<em>(3)</em></a>
													</li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Fresas y sangre =&quot;.T245.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=T245"">Fresas
															y sangre =<em>(2)</em></a></li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Solera&quot;.T245.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=T245"">Solera<em>(2)</em></a>
													</li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Bikini mix&quot;.T245.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=T245"">Bikini
															mix<em>(2)</em></a></li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Lo mejor de la Fono Music&quot;.T245.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=T245"">Lo
															mejor de la Fono Music<em>(1)</em></a></li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Clic Clic visita a su amiga Coc�&quot;.T245.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=T245"">Clic
															Clic visita a su amiga Coc�<em>(1)</em></a></li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Coco avant Chanel&quot;.T245.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=T245"">Coco
															avant Chanel<em>(1)</em></a></li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Cantananas.&quot;.T245.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=T245"">Cantananas.<em>(1)</em></a>
													</li>

												</ul>

												<div>Materia <a class=""T650"" name=""next-face0""
														href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=131&amp;NEXTFACE=1&amp;fieldFace=T650""
														onclick=""AbnOpacNextFace(this);return false;""
														style=""display:none"">&#187; M�s</a></div>
												<ul class=""T650-ul"">

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Ni�os&quot;.T650.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=T650"">Ni�os<em>(4)</em></a>
													</li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Pop-rock&quot;.T650.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=T650"">Pop-rock<em>(3)</em></a>
													</li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Poesias italianas&quot;.T650.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=T650"">Poesias
															italianas<em>(2)</em></a></li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Canciones infantiles&quot;.T650.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=T650"">Canciones
															infantiles<em>(2)</em></a></li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Lengua italiana&quot;.T650.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=T650"">Lengua
															italiana<em>(2)</em></a></li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Animales&quot;.T650.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=T650"">Animales<em>(2)</em></a>
													</li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Educaci�n sanitaria&quot;.T650.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=T650"">Educaci�n
															sanitaria<em>(2)</em></a></li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Flamenco&quot;.T650.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=T650"">Flamenco<em>(2)</em></a>
													</li>

												</ul>

												<div>Fecha <a class=""FEPU"" name=""next-face0""
														href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=131&amp;NEXTFACE=1&amp;fieldFace=FEPU""
														onclick=""AbnOpacNextFace(this);return false;""
														style=""display:none"">&#187; M�s</a></div>
												<ul class=""FEPU-ul"">

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;A�os 90&quot;.FEPU.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=FEPU"">A�os
															90<em>(77)</em></a></li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;2004&quot;.FEPU.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=FEPU"">2004<em>(16)</em></a>
													</li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;2006&quot;.FEPU.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=FEPU"">2006<em>(13)</em></a>
													</li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;A�os 80&quot;.FEPU.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=FEPU"">A�os
															80<em>(13)</em></a></li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;2003&quot;.FEPU.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=FEPU"">2003<em>(12)</em></a>
													</li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;2000&quot;.FEPU.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=FEPU"">2000<em>(12)</em></a>
													</li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;2008&quot;.FEPU.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=FEPU"">2008<em>(11)</em></a>
													</li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;2001&quot;.FEPU.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=FEPU"">2001<em>(10)</em></a>
													</li>

												</ul>

												<div>Anal�ticas <a class=""LENG"" name=""next-face0""
														href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=131&amp;NEXTFACE=1&amp;fieldFace=LENG""
														onclick=""AbnOpacNextFace(this);return false;""
														style=""display:none"">&#187; M�s</a></div>
												<ul class=""LENG-ul"">

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Espa�ol&quot;.LENG.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=LENG"">Espa�ol<em>(148)</em></a>
													</li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Italiano&quot;.LENG.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=LENG"">Italiano<em>(14)</em></a>
													</li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;M�ltiple&quot;.LENG.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=LENG"">M�ltiple<em>(13)</em></a>
													</li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;13]&quot;.LENG.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=LENG"">13]<em>(6)</em></a>
													</li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;013&quot;.LENG.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=LENG"">013<em>(6)</em></a>
													</li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Portugu�s&quot;.LENG.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=LENG"">Portugu�s<em>(4)</em></a>
													</li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;..T&quot;.LENG.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=LENG"">..T<em>(2)</em></a>
													</li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;[T&quot;.LENG.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=LENG"">[T<em>(1)</em></a>
													</li>

												</ul>

												<div>Tipo de registro <a class=""LD06,LD07"" name=""next-face0""
														href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=131&amp;NEXTFACE=1&amp;fieldFace=LD06,LD07""
														onclick=""AbnOpacNextFace(this);return false;""
														style=""display:none"">&#187; M�s</a></div>
												<ul class=""LD06,LD07-ul"">

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Monograf�as&quot;.LD06,LD07.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=LD06,LD07"">Monograf�as<em>(96)</em></a>
													</li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;M�sica&quot;.LD06,LD07.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=LD06,LD07"">M�sica<em>(89)</em></a>
													</li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Material proyectable&quot;.LD06,LD07.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=LD06,LD07"">Material
															proyectable<em>(13)</em></a></li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Recursos electr�nicos&quot;.LD06,LD07.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=LD06,LD07"">Recursos
															electr�nicos<em>(1)</em></a></li>

													<li><a
															href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=131&amp;srch=&quot;Material no proyectable&quot;.LD06,LD07.&amp;xsface=on&amp;etapaFace=1&amp;fieldFace=LD06,LD07"">Material
															no proyectable<em>(1)</em></a></li>

												</ul>

												<br />
											</div>
										</div>
									</div>
									<div id=""tabdesc"" class=""dvNone""><a name=""tagdesc""></a>
										<div class=""contentTag"">
											<div class=""facetit nborder"">

												<ul id=""xxauto"">

													<li><a href=""""></a></li>


												</ul><br />
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
						<div class=""empty""></div>
						<br />
						<div class=""regdoc"">

							<span class=""acti"">1</span><span class='barr'>&nbsp;|&nbsp;</span><a
								href='/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=161&amp;DOC=11'
								class='noacti' title=""Registro 11 / 20""
								onclick='AbnOpacListDoc(""11"");return false;'>2</a><span
								class='barr'>&nbsp;|&nbsp;</span><a
								href='/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=161&amp;DOC=21'
								class='noacti' title=""Registro 21 / 30""
								onclick='AbnOpacListDoc(""21"");return false;'>3</a><span
								class='barr'>&nbsp;|&nbsp;</span><a
								href='/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=161&amp;DOC=31'
								class='noacti' title=""Registro 31 / 40""
								onclick='AbnOpacListDoc(""31"");return false;'>4</a><span
								class='barr'>&nbsp;|&nbsp;</span><a
								href='/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03?ACC=161&amp;DOC=41'
								class='noacti' title=""Registro 41 / 50""
								onclick='AbnOpacListDoc(""41"");return false;'>5</a>

							<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=161&amp;DOC=11""
								onclick=""AbnOpacListDoc(11);return false;"" title=""Siguiente"" class=""noacti"">&#187;</a>

						</div>
						<div class=""reglist"">
							<div class=""reglistl"">
								<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=264""
									onclick=""AbnOpacCheckAll();return false;"" class=""butt_send""><i
										class=""fa check-square"" aria-hidden=""true"">&#xf14a;</i><span>Marcar
										todos</span></a>
								<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=268""
									onclick=""AbnOpacCheckList();return false;"" class=""butt_send ""><i
										class=""fa check-square-o"" aria-hidden=""true"">&#xf046;</i><span>Marcar
										b�squeda</span></a>
								<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=120""
									class=""butt_send""><i class=""fa search"" aria-hidden=""true"">&#xf002;</i><span>Volver a
										Buscar</span></a>

							</div>
							<div class=""reglistr"">

								<div class=""toggle-picker toggle-list"">
									<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=161&amp;DOC=10&amp;LISTMOSAIC=-1""
										onclick=""AbnOpacListMosaic(-1);return false;"" title=""Vista de lista""></a>
									<div class=""picker layout-picker"">
										<div class=""picker-inner picker-last-col""></div>
										<div class=""picker-inner picker-last-col""></div>
										<div class=""picker-inner picker-last-row picker-last-col""></div>
									</div>
								</div>
								<div class=""toggle-picker toggle-mosaic"">
									<a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=161&amp;DOC=10&amp;LISTMOSAIC=1""
										onclick=""AbnOpacListMosaic(1);return false;"" title=""Vista de im�genes""></a>
									<div class=""picker image-layout-picker"">
										<div class=""picker-inner""></div>
										<div class=""picker-inner picker-last-col""></div>
										<div class=""picker-inner picker-last-row""></div>
										<div class=""picker-inner picker-last-row picker-last-col""></div>
									</div>
								</div>
								<h3 class=""recordsetlist"">Registros <strong>10/10</strong> de <strong>873</strong></h3>
							</div>
							<div class=""empty""></div>
						</div>
						<br />
					</div>
				</div>
				<script type=""text/javascript"">
					/*<![CDATA[*/
					function AbnChgHist() {
						document.abnophist.submit();
					}
					function OpenLinkSrch() {
						if (document.abnform.xsqf01.value == """") return false;
						Loading(); document.abnform.submit();
					}
					function AbnOpacDoc(ndoc) {
						if (ndoc < 1 || ndoc > 873 || isNaN(ndoc))
							return;
						document.abnoplist.DOC.value = ndoc;
						document.abnoplist.ACC.value = 165;
						document.abnoplist.submit();
					}
					function AbnOpacListDoc(ndoc) {
						if (ndoc < 1 || ndoc > 873)
							return;
						document.abnoplist.DOC.value = ndoc;
						document.abnoplist.ACC.value = 161;
						document.abnoplist.submit();
					}
					function AbnOpacCheck(ndoc, obj) {
						if (ndoc < 1 || ndoc > 873)
							return;
						var param = ""&ACC=266&DOC="" + ndoc + ""&httprequest=1""; responsePost(""./"", param); putCheck(obj);
					}
					function AbnOpacCheckAll() {
						var param = ""&ACC=264&httprequest=1"", ret = responsePost(""./"", param);
						putCheckAll(0, ret);
					}
					function AbnOpacCheckList() {
						var param = ""&ACC=268&httprequest=1"", arr;
						var ret = responsePost(""./"", param);
						if (ret) {
							arr = ret.split(/\|\|/g); A$(""md"").innerHTML = arr[0]; A$(""cbubble"").className = arr[1]; putCheckAll(arr[2]);
						} else { putCheckAll(); }
					}
					function AbnOpacListMosaic(n) {
						var ndoc = 10;
						if (ndoc < 873) {
							ndoc -= 1;
						}
						document.abnoplist.DOC.value = ndoc;
						document.abnoplist.ACC.value = 161;
						document.abnoplist.LISTMOSAIC.value = n;
						document.abnoplist.submit();
					}
					function AbnOpacAuto(t) {
						try {
							var dc = A$('xxauto'), dv, li = dc.getElementsByTagName('li')[0], href = li.getElementsByTagName('a')[0];
							if (dc && li && href && !href.innerHTML.length) {
								Loading();
								setTimeout(function () {
									var param = ""&ACC=131&CLV=1&httprequest=1&xsface=on"",
										ret = responsePost(""./"", param);
									if (ret) {
										var regExp = /<ul\s+id=""xxauto"">[\S\s]*?<\/ul>/gi, regExp1 = new RegExp('<div id=""xxtiau"">(.*?)</div>', ""gi""),
											arMatch = regExp.exec(ret), arMatch1 = regExp1.exec(ret);
										if (arMatch) {
											dc.innerHTML = arMatch[0];
										} if (arMatch1) {
											dv = document.createElement(""div"");
											dv.appendChild(document.createTextNode(arMatch1[1]));
											dc.parentNode.insertBefore(dv, dc);
										} LoadingHide();
										selTab(t);
									};
								}, 0);
							} else {
								selTab(t);
							}
						} catch (e) { LoadingHide() }
					}
					function AbnOpacNextFace(t) {
						try {
							Loading();
							setTimeout(function () {
								var id = t.getAttribute('class'),
									param = ""&ACC=131&NEXTFACE=1&fieldFace="" + id,
									ret = responsePost(""./"", param);
								if (ret) {
									var regExp = new RegExp('<ul class=""' + id + '-ul"">(.|\n)+?</ul>', ""gi""), regExp1 = new RegExp('class=""' + id + '""(.|\n)+?</a>', ""gi""),
										arMatch = regExp.exec(ret), arMatch1 = regExp1.exec(ret), last, str;
									if (arMatch) {
										document.getElementsByClassName(id + '-ul')[0].outerHTML = arMatch[0];
										if (arMatch1) {
											last = arMatch1.toString().match(/ name=(.*?) /);
											if (last && last[0]) {
												str = last[0].replace(/[^0-9]/gi, '');
												if (str.length > 1) {
													str = parseInt(str.substring(str.length, str.length - 1), 10);
												}
												if (parseInt(str, 10)) {
													document.getElementsByClassName(id)[0].style.display = 'none';
												}
											}
										}
									} LoadingHide();
								};
							}, 0);
						} catch (e) { LoadingHide() }
					}
					function selTab(t) {
						activateTab(t.parentNode, 'tabdesc', 'tabface');
					}
					function ChgSubcat() { OpenLinkSrch(); }
					function ChgSubcatMenu(obj) {
						A$('selection').innerHTML = obj.innerHTML;
						document.abnform.subcat.value = obj.getAttribute(""id"");
						OpenLinkSrch();
					}
					// crear icono vista previa
					vistaPrevia(0)
/*]]>*/
				</script>
			</div>
		</div>
		<div class=""empty""></div>
	</div>
	<div class=""copyright"">
		<a name=""contact_lnk"" class=""copy""></a>
		<ul class=""lnkLogo"">
			<li><img src=""/biblio_publicas/imag/media/logopie.png"" /></li>
			<li>&#169; BPCM 2013-2016</li>
		</ul>
		<ul class=""lnkweb"">
			<li><a href=""http://www.madrid.org/cs/Satellite?c=Page&cid=1109265698478&language=es&pagename=ComunidadMadrid%2FEstructura&pid=1109265698438&sc=2""
					target=""_blank"">Sugerencias y quejas</a></li>
		</ul>
		<ul class=""lnkweb"">
			<li><a href=""http://www.madrid.org/cs/Satellite?pagename=ComunidadMadrid/Comunes/Presentacion/popUp&language=es&c=CM_Texto_FA&cid=1142636148876""
					target=""_blank"">Aviso legal</a></li>
			<li><a href=""mailto:redbibliotecasmadrid@madrid.org"">Contacto</a></li>
			<li><a href=""http://www.madrid.org/cs/Satellite?pagename=ComunidadMadrid/Comunes/Presentacion/popUp&language=es&c=CM_Texto_FA&cid=1109266097450""
					target=""_blank"" accesskey=""5"">Accesibilidad</a></li>
			<li><a href=""/biblio_publicas/cgi-bin/abnetopac/O9724/ID5504fa03/NT1?ACC=142"" accesskey=""4"">Mapa Web</a>
			</li>
		</ul>
		<div class=""empty""></div>
	</div>
	<div id=""upPage"">
		<a href=""#"" id=""upPageA"" onclick=""scrollToTop(500); return false""><i class=""fa fa-arrow-circle-up""
				aria-hidden=""true""></i></a></div>
	<script type=""text/javascript"">
		function upPageScroll(event) {
			var top = this.scrollY;
			var up = A$(""upPage"");
			if (up) {
				if (top > 200) {
					up.style.display = ""block"";
				}
				else {
					up.style.display = ""none"";
				}
			}
		}
		if (window.attachEvent) {
			window.attachEvent(""onscroll"", upPageScroll);
		}
		else if (window.addEventListener) {
			window.addEventListener(""scroll"", upPageScroll, false);
		}
		function scrollToTop(scrollDuration) {
			var scrollStep = -window.scrollY / (scrollDuration / 15),
				scrollInterval = setInterval(function () {
					if (window.scrollY != 0) {
						window.scrollBy(0, scrollStep);
					}
					else clearInterval(scrollInterval);
				}, 15);
		}
	</script>
</body>

</html>";
        }
    }
}
