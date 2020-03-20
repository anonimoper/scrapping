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

			//LibraryService libraryService = new LibraryService();
			string codeAPI = LibraryService.GetCodeApiHTTP();
			//libraryService.CodeApi = "O9473/ID91fd4fa3";

			if (codeAPI != "")
			{
				string codeExit = "";
				string search = "";
				string numberBook = "";
				string html = "";
				do
				{
					Console.WriteLine("Write Book Search Library:");
					search = Console.ReadLine();
					Console.WriteLine("Number book list:");
					numberBook = Console.ReadLine();
					html = LibraryService.GetHtmlSearchHTTP(search, Int32.Parse(numberBook), codeAPI);
					List<Book> listBook = LibraryScrapping.GetBooksSearch(html);

					Book book = listBook.ElementAt(0);
					html = LibraryService.GetHtmlLoanBook(book.ACC, book.DOC, codeAPI);
					List<LoanCity> loanCity = LibraryScrapping.GetLoanCityBook(html);
					Console.WriteLine("Continue press S if you want exit press N");
					codeExit = Console.ReadLine();
				}
				while (codeExit != "N");

			}
		}

		static string getHtmlBookTest()
        {
            return @"
<?xml version=""1.0""?>
<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"" xml:lang=""es-ES"">
    <head>
        <!-- Copyright (c) 1999-2011, baratz  Servicios de Teledocumentacion, S.A. http://www.baratz.es (Red de Bibliotecas de la Comunidad de Madrid) -->
        <!-- compilation: ""Nov 12 2019"" date: ""2019-12-23 14:44:32"" version: ""2.2""-->
        <!-- abnetcl: ""Nov_13_2019_2_2"" -->
        <!-- REQUEST_SCHEME: ""http"" -->
        <!-- HTTPS: """" -->
        <!-- log level: ""1"" -->
        <!-- log file: """" -->
        <!-- log configuration file: """" -->
        <meta http-equiv=""Expires"" content=""Fri, 1 Jan 1999 08:00:00 WET""/>
        <meta http-equiv=""Pragma"" content=""no-cache""/>
        <meta http-equiv=""Content-Type"" content=""text/html; charset=iso-8859-1""/>
        <link rel=""canonical"" href=""https://gestiona3.madrid.org:443/biblio_publicas/cgi-bin/abnetopac?TITN=1788207""/>
        <title>Catálogos de las Bibliotecas de la Comunidad de Madrid La novela de la Costa Azul</title>
        <link rel=""stylesheet"" href=""/biblio_publicas/imag/style1.css"" type=""text/css""/>
        <script type=""text/javascript"">this.sDirHttp = ""/biblio_publicas"";
function timeout(){parent.parent.document.location=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda?ACC=301"";}window.setTimeout(timeout,392000);
</script>
        <script type=""text/javascript"" src=""/biblio_publicas/js/utils.js""></script>
        <!--[if IE]>
        <style type=""text/css"">#clay {filter: alpha(opacity=10)}</style>
        <![endif]-->
        <!--[if lte IE 7]>
        <style type=""text/css"">.tabsections {overflow:hidden;display:inline-block},.social_links {background:none!important;border:0!important}</style>
        <![endif]-->
        <meta name=""theme-color"" content=""#024467"" />
        <link rel=""shortcut icon"" type=""image/x-icon"" href=""/biblio_publicas/favicon.png"" />
    </head>
    <body>
        <!-- file displayDoc.htm -->
        <div id=""skiplinks"">
            <a href=""#skip"" accesskey=""s"">Saltar contenido</a> |
        </div>
        <div id=""access"">
            <a href=""#usuari_lnk"">Usuario</a> |
            <a href=""#tools_lnk"">Inf. Biblioteca</a> |
            <a href=""#contact_lnk"">Pié de página</a>
            <h1>absysNET Opac 2.0</h1>
            <h2>
[ 
                <acronym lang=""en"" xml:lang=""en"" title=""Web Accessibility Initiative"">WAI</acronym> &middot;
                <acronym lang=""en"" xml:lang=""en"" title=""Web Accessibility Test"">TAW</acronym> &middot;
                <acronym lang=""en"" xml:lang=""en"" title=""Cascading Style Sheets"">CSS</acronym> &middot;
JavaScript &middot;
                <acronym lang=""en"" xml:lang=""en"" title=""eXtensible HyperText Markup Language"">XHTML</acronym> ]
            </h2>
        </div>
        <div id=""main"">
            <div id=""clay""></div>
            <div id=""com"" class=""com""></div>
            <div class=""menu"" >
                <a href=""http://www.madrid.org"" title=""Comunidad de Madrid"" target=""_blank"">
                    <img id=""comMad"" src=""/biblio_publicas/imag/especificas/commadrid.png"" alt=""Comunidad de Madrid""/>
                </a>
                <a href=""http://www.madrid.org/bibliotecas"" title=""Bibliotecas de la Comunidad de Madrid"" target=""_blank"">
                    <img id=""bcoMad""  src=""/biblio_publicas/imag/especificas/logoPeq.png"" alt=""Bibliotecas de la Comunidad de Madrid""/>
                </a>
            </div>
            <div class=""empty""></div>
            <div id=""loading"">Procesando, espere por favor...
                <br/>
                <img src=""/biblio_publicas/imag/loading1.gif"" alt=""loading..""/>
                <br/>
            </div>
            <div id=""catMenu"">
                <ul>
                    <li>
                        <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=101"" accesskey=""1"" title=""Volver a la página principal del Opac"">Inicio</a>
                    </li>
                    <li>
                        <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=120"" accesskey=""2"" title=""Regresar al formulario de consulta"">Buscar</a>
                    </li>
                    <li>
                        <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=260"" id=""last_items1"" title=""Visualizar la lista de documentos marcados"">Marcados</a>
                    </li>
                    <li>
                        <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=300&amp;HELPID=DOC"" accesskey=""3"" title=""Ayuda sobre esta pantalla"">Ayuda</a>
                    </li>
                    <li>
                        <a id=""loginUser"" href=""#"" onclick=""cierra('userpass')"" onmouseover=""abre('userpass')"">Área de usuario
                            <i class=""fa user fa-fw"">&#xf007;

                                <div id=""mensajeLogin"">Servicio disponible para usuarios registrados en la biblioteca.</div>
                            </i>
                        </a>
                        <h2 class=""nd"">Usuario
                            <span class=""anchor"">
                                <a name=""usuari_lnk""></a>
                            </span>
                        </h2>
                        <ul id=""userpass"">
                            <fieldset title=""Formulario de identificación de usuarios"">
                                <legend>Formulario de identificación de usuarios</legend>
                                <form action=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT1"" method=""post"" id=""abnopid"" name=""abnopid"">
                                    <input type=""hidden"" name=""FBC"" value=""316""/>
                                    <input type=""hidden"" name=""NAC"" value=""317""/>
                                    <input type=""hidden"" name=""ACC"" value=""201""/>
                                    <noscript>
                                        <input type=""hidden"" name=""NSSL"" value=""1""/>
                                    </noscript>
                                    <!--label for=""leid"">Nº de carné / Correo electrónico</label><span class=""lectorleid""><label for=""lepass"">contraseña</label></span-->
                                <li>
                                    <i class=""fa user fa-fw"">&#xf007;</i>
                                    <input type=""text"" name=""leid"" id=""leid"" placeholder=""Nº de carné"" title=""Nº de carné de la biblioteca"" />
                                </li>
                                <li>
                                    <i class=""fa key fa-fw"">&#xf084;</i>
                                    <input type=""password"" name=""lepass"" id=""lepass"" maxlength=""63"" placeholder=""Contraseña"" title=""Contraseña""/>
                                    <p class=""errorlog"">
                                        <span></span>
                                    </p>
                                </li>
                                <!--div class=""lectoradd""-->
                                <li class=""lectoradd"">
                                    <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT1?ACC=218"" target=""_blank"" onclick=""openw(this,550,(agentBrowser('Chrome'))?400:340);return false;"">¿Has olvidado tu contraseña?</a>
                                </li>
                                <script type=""text/javascript"">/*
                                    <![CDATA[*/
writeTag('<li class=""logBut""><a href=""#"" onclick=""AbnOpacId();return false;"" class=""butt_send"">Conectar</a></li>'/*]]>*/);
-->
                                </script>
                                <!--/div-->
                                <noscript>
                                    <input type=""submit"" class=""butt_send"" value=""Conectar""/>
                                </noscript>
                            </form>
                        </fieldset>
                    </ul>
                </li>
            </ul>
        </div>
        <div class=""container"">
            <div class=""content"">
                <div id=""results"">
                    <h2>
                        <a name=""skip""></a>
                        <i class=""fa tags fa-fw"">&#xf02c;</i> Búsqueda Avanzada
                    </h2>
                    <div class=""listadoc"">
                        <form action=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8"" method=""post"" id=""abnform"" name=""abnform"">
                            <input type=""hidden"" name=""ACC"" value=""165""/>
                            <input type=""hidden"" name=""DOC"" value=""2""/>
                            <input type=""hidden"" name=""BRS"" value=""""/>
                            <input type=""hidden"" name=""LISTDSI"" value=""0""/>
                        </form>
                        <br/>
                        <form action=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8"" method=""post"" id=""abnhist"" name=""abnhist"">
                            <input type=""hidden"" name=""ACC"" value=""137""/>
                            <input type=""hidden"" name=""DOC"" value=""2""/>
                            <input type=""hidden"" name=""BRS"" value=""""/>
                            <div class=""breakp subcat"">
                                <label for=""xshist"">Buscando</label>
                                <select id=""xshist"" name=""xshist"" onchange=""AbnChgHist();"">
                                    <option value=""1"">Cualquier campo: coco/</option>
                                </select>
&nbsp;
                                <strong>en&nbsp;</strong>
                                <noscript>
                                    <input type=""submit"" class=""butt_send"" value=""Enviar""/>
                                </noscript>
                            </div>
                        </form>
                        <br/>
                        <div class=""facedoc levelface "">
                            <span>Búsqueda facetada</span>
                            <img src=""/biblio_publicas/imag/arrow_face.gif"" alt="" ""/>&nbsp;
                            <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda?ACC=131&amp;xsqf01=(coco)&amp;xsface=on&amp;etapaFace=0&amp;fieldFace=&amp;xindbt="">(coco)</a>&nbsp;
                        </div>
                        <br/>
                        <div class=""reglist"">
                            <div class=""reglistl"">
                                <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda?ACC=161&amp;DOC=2""  onclick=""AbnOpacListDoc('2');return false;"" class=""butt_send"">
                                    <i class=""fa list"" aria-hidden=""true"">&#xf03a;</i>Resultados
                                </a>
                                <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=120"" class=""butt_send"">
                                    <i class=""fa search"" aria-hidden=""true"">&#xf002;</i>Volver a Buscar
                                </a>
                            </div>
                            <div class=""reglistr"">
                                <h3 class=""recordsetlist"">Registro 
                                    <strong>2</strong> de
                                    <strong>875</strong>
                                </h3>
                                <form action=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8"" method=""post"">
                                    <input type=""hidden"" name=""ACC"" value=""165""/>
                                    <input type=""hidden"" name=""DOC"" value=""2""/>
                                    <input type=""hidden"" name=""xsrmax"" value=""875""/>
|
                                    <input type=""text"" id=""inregt"" name=""inregt"" class=""inpreg"" value=""2"" title=""""/>
                                    <script type=""text/javascript"">/*
                                        <![CDATA[*/writeTag('<a href=""#"" id=""n0"" onclick=""AbnOpacDoc(A$(\'inregt\').value);return false;"" class=""butt_send""  title=""""><i class=""fa fa-check"" aria-hidden=""true""></i></a>')/*]]>*/
                                    </script>
                                    <noscript>
                                        <input type=""submit"" name=""xsregt"" class=""butt_send"" value=""Registro""/>
                                    </noscript>
                                </form>
                            </div>
                            <div class=""empty""></div>
                        </div>
                        <br/>
                        <div class=""regdoc"">
                            <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=165&amp;DOC=1&amp;LISTDSI=0"" onclick=""AbnOpacDoc(1);return false;"" title=""Anterior"" class=""noacti"">&#171;</a>
                            <a href='/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda?ACC=165&amp;DOC=1' class='noacti' title=""Registro 1"" onclick='AbnOpacDoc(""1"");return false;'>1</a>
                            <span class='barr'>&nbsp;|&nbsp;</span>
                            <span class='acti'>2</span>
                            <span class='barr'>&nbsp;|&nbsp;</span>
                            <a href='/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda?ACC=165&amp;DOC=3' class='noacti' title=""Registro 3"" onclick='AbnOpacDoc(""3"");return false;'>3</a>
                            <span class='barr'>&nbsp;|&nbsp;</span>
                            <a href='/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda?ACC=165&amp;DOC=4' class='noacti' title=""Registro 4"" onclick='AbnOpacDoc(""4"");return false;'>4</a>
                            <span class='barr'>&nbsp;|&nbsp;</span>
                            <a href='/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda?ACC=165&amp;DOC=5' class='noacti' title=""Registro 5"" onclick='AbnOpacDoc(""5"");return false;'>5</a>
                            <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=165&amp;DOC=3&amp;LISTDSI=0"" onclick=""AbnOpacDoc(3);return false;"" title=""Siguiente"" class=""noacti"">&#187;</a>
                        </div>
                        <div class=""dvreg dvregdoc"">
                            <br/>
                            <div class=""tabcontent"">
                                <div id=""tabsistem"" class=""tabsistem""></div>
                                <script type=""text/javascript"">/*
                                    <![CDATA[*/
ujson.cc = {mx:""875"", dsi:""0"", tab_active:""""};
writeTabs(""Documento"",""Colecciones"",""Ejemplares"",""Comentarios"",""Etiquetas"");
/*]]>*/
                                </script>
                                <div class=""tabsections"">
                                    <div id=""divL1"" class=""divDoc"">
                                        <div class=""docmat"">
                                            <div class=""dochek"">
                                                <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda?ACC=261"" onclick=""AbnOpacCheckDoc(this);return false;"">
                                                    <img src=""/biblio_publicas/imag/check1.gif"" alt=""Desmarcar""/>
                                                </a>&nbsp;
                                                <img src=""/biblio_publicas/imag/mater01.gif"" title=""Monografías"" alt=""Monografías""/>
                                            </div>
                                            <form action=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8"" method=""post"" id=""abnfmat"" name=""abnfmat"">
                                                <input type=""hidden"" name=""ACC"" value=""165""/>
                                                <input type=""hidden"" name=""DOC"" value=""2""/>
                                                <input type=""hidden"" name=""BRS"" value=""""/>
                                                <input type=""hidden"" name=""LISTDSI"" value=""0""/>
                                                <div class=""docfmt"">
                                                    <select id=""xsfmtd"" name=""xsfmtd"" onchange=""AbnChgFormat();"">
                                                        <option value=""36562448"" selected=""selected"">Visualización Etiquetas</option>
                                                        <option value=""36563024"">Visualización ISBD</option>
                                                        <option value=""36563568"">Visualización MARC</option>
                                                        <option value=""36564304"">Visualización MARCXML</option>
                                                    </select>
                                                    <noscript>
                                                        <input type=""submit"" class=""butt_send"" value=""Formato""/>
                                                    </noscript>
                                                </div>
                                            </form>
                                        </div>
                                        <div class=""docum"">
                                            <div class=""docmmx"">
                                                <div class=""coverDoc"">
                                                    <script type=""text/javascript"">/*
                                                        <![CDATA[*/writeTag('<a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda?ACC=294&amp;DOC=2&amp;MLKOB=593655664848"" class=""cover"" title=""Cubierta"" target=""_blank""><img src=""/biblio_publicas/imag/loading.gif"" url=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda?ACC=307&amp;MLKOB=593655664848"" onload=""putUrl(this)""/></a>')/*]]>*/
                                                    </script>
                                                    <noscript>
                                                        <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda?ACC=294&amp;DOC=2&amp;MLKOB=593655664848"" class=""cover"" title=""Cubierta"" target=""_blank"">
                                                            <img src=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda?ACC=307&amp;MLKOB=593655664848"" alt=""Cubierta""/>
                                                        </a>
                                                    </noscript>
                                                </div>
&nbsp;
                                            </div>
                                            <div class=""doctit"">
                                                <form action=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8"" method=""post"" target=""_blank"" id=""abndocu"" name=""abndocu"">
                                                    <input type=""hidden"" name=""ACC"" value=""182""/>
                                                    <input type=""hidden"" name=""ADDDES_READ"" value=""1""/>
                                                    <div class=""listadoc"">
                                                        <div class=""dvdoc entity"">
                                                            <div class=""auth"">
                                                                <strong>Autor/Autora:</strong>
                                                            </div>
                                                            <div class=""titn"">
                                                                <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda?ACC=133&#38;NAUT=578574&#38;SAUT=Scaraffia,+Giuseppe+(1950-)"">Scaraffia, Giuseppe (1950-)</a>
                                                            </div>
                                                            <div class=""auth"">
                                                                <strong>Título:</strong>
                                                            </div>
                                                            <div class=""titn"">La novela de la Costa Azul / Giuseppe Scaraffia ; traducción de Francisco Campillo</div>
                                                            <div class=""auth"">
                                                                <strong>Edición:</strong>
                                                            </div>
                                                            <div class=""titn"">1ª ed.</div>
                                                            <div class=""auth"">
                                                                <strong>Publicación:</strong>
                                                            </div>
                                                            <div class=""titn"">Cáceres : Periférica, 2019
                                                                <br/>
                                                            </div>
                                                            <div class=""auth"">
                                                                <strong>Descripción física:</strong>
                                                            </div>
                                                            <div class=""titn"">429 p. ; 21 cm
                                                                <br/>
                                                            </div>
                                                            <div class=""auth"">
                                                                <strong>Colección:</strong>
                                                            </div>
                                                            <div class=""titn"">Largo recorrido ; 138
                                                                <br/>
                                                            </div>
                                                            <div class=""auth"">
                                                                <strong>Tipo de contenido:</strong>
                                                            </div>
                                                            <div class=""titn"">Texto (visual) </div>
                                                            <div class=""auth"">
                                                                <strong>Tipo de medio:</strong>
                                                            </div>
                                                            <div class=""titn"">sin mediación </div>
                                                            <div class=""auth"">
                                                                <strong>Resumen:</strong>
                                                            </div>
                                                            <div class=""titn"">""La fascinante historia de un lugar mítico y de los personajes legendarios que vivieron en él... De Chéjov a Stefan Zweig, de Scott y Zelda Fitzgerald a 
                                                                <span style=""color:#f00"">Coco</span> Chanel; pasando por Maupassant, Nietzsche, Picasso, Alma Mahler, Aldous Huxley, Katherine Mansfield, Walter Benjamin, Anaïs Nin, Somerset Maugham o Nabokov, entre muchos otros. Durante siglos, la Costa Azul fue un lugar olvidado, donde embarcarse o desembarcar. Pero, ya
a principios del XX, Jean Lorrain dijo: todos los chalados del mundo se dan cita aquí. Sin embargo, para la mayoría de escritores y artistas era justamente lo contrario: un lugar de soledad, creación, reflexión; un lugar donde descansar de la ciudad...""--Contracubierta
                                                            </div>
                                                            <div class=""auth"">
                                                                <strong>Nota al título y responsables:</strong>
                                                            </div>
                                                            <div class=""titn"">Título original: Il romanzo della Costa Azurra
                                                                <br/>
                                                            </div>
                                                            <div class=""auth"">
                                                                <strong>ISBN:</strong>
                                                            </div>
                                                            <div class=""titn"">9788416291823
                                                                <br/>
                                                            </div>
                                                            <div class=""auth"">
                                                                <strong>Género</strong>:
                                                            </div>
                                                            <div class=""titn"">
                                                                <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda?ACC=133&#38;NAUT=585760&#38;SAUT=Novelas"">Novelas</a>
                                                                <br/>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- Campos con etiquetas especiales -->
                                                    <input type=""hidden"" name=""wntitn"" value=""1788207""/>
                                                    <input type=""hidden"" name=""wntitl"" value=""La novela de la Costa Azul / ""/>
                                                    <input type=""hidden"" name=""wnauth"" value=""Scaraffia, Giuseppe (""/>
                                                    <div class=""docmak"">

</div>
                                                </form>
                                                <!--IFVAR:0=1-->
                                                <ul class=""social_links"">
                                                    <li>
                                                        <script type=""text/javascript"">/*
                                                            <![CDATA[*/writeTag('<fb:like href=""https://gestiona3.madrid.org/biblio_publicas/cgi-bin/abnetopac?TITN=1788207"" layout=""button_count"" font=""verdana""></fb:like>')/*]]>*/
                                                        </script>
                                                    </li>
                                                    <li>
                                                        <div id=""plusone-div""></div>
                                                    </li>
                                                    <li>
                                                        <a href=""https://twitter.com/share?text_=&amp;hashtags_=absysNET&amp;via_="" id=""twiter_share"" class=""twitter-share-button""></a>
                                                    </li>
                                                    <li>
                                                        <div class=""docmak"">
                                                            <input type=""image"" src=""/biblio_publicas/imag/marcador.gif"" onclick=""ft();return false;"" alt=""Marcador"" title=""Haz clic aquí para añadir este registro a tu marcador social""/>
                                                        </div>
                                                    </li>
                                                </ul>
                                                <div id=""fb-root""></div>
                                                <script type=""text/javascript"">/*
                                                    <![CDATA[*/ujson.like='https://gestiona3.madrid.org/biblio_publicas/cgi-bin/abnetopac?TITN=1788207';plSocial();/*]]>*/
                                                </script>
                                                <!--/IFVAR-->
                                            </div>
                                            <div class=""empty""></div>
                                        </div>
                                    </div>
                                    <div id=""divL2"" class=""divDoc divTabs""></div>
                                    <div id=""divL3"" class=""divDoc divTabs"">
                                        <br/>
                                        <div id=""showdis""></div>
                                        <br/>
                                        <div id=""ejDetail"">
                                            <div class=""detmain detbib"">
                                                <strong>Biblioteca</strong>:
                                                <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=271&amp;BI=BPM"" onclick=""openw(this,600,400);return false;"" target=""_blank"">MADRID. Bibliotecas Públicas</a>
                                                <br/>
                                                <div class=""dtSuc"">
                                                    <img src=""/biblio_publicas/imag/bullet03.gif"" alt="" ""/>
&nbsp;
                                                    <strong>Sucursal</strong>:
                                                    <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=273&amp;SU=BCDIB"" onclick=""openw(this,600,400);return false;"" target=""_blank"">CARABANCHEL. BP Ana Mª Matute</a>
&nbsp;
                                                    <span class=""linkDespliega"" style=""color:#0000FF"" onclick=""detail_copias(this);"">&#91;Desplegar ejemplares&#93;</span>
                                                </div>
                                                <table class=""dtNone"" summary=""Información de los ejemplares disponibles"">
                                                    <tr>
                                                        <th class=""newDetail""></th>
                                                        <th scope=""col"">Localización
                                                            <br>Tipo de lector
                                                        </th>
                                                        <th scope=""col"">Tipo de ejemplar</th>
                                                        <th scope=""col"">Signatura</th>
                                                        <th scope=""col"">Disponibilidad</th>
                                                        <th scope=""col"">Soporte</th>
                                                    </tr>
                                                    <tr>
                                                        <td class=""newDetail""></td>
                                                        <td>Sala adultos&nbsp;
                                                            <br>Adultos&nbsp;
                                                        </td>
                                                        <td>Prestable. Libros</td>
                                                        <td>
                                                            <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=143&amp;SIGN=N SCA nov&amp;BC=1400768723"">N SCA nov</a>&nbsp;
                                                            <br>NOVEDAD&nbsp;
                                                            <br>&nbsp; 
                                                        </td>
                                                        <td>Disponible después de 02/01/2020&nbsp;</td>
                                                        <td>Libro</td>
                                                    </tr>
                                                </table>
                                                <div class=""dtSuc"">
                                                    <img src=""/biblio_publicas/imag/bullet03.gif"" alt="" ""/>
&nbsp;
                                                    <strong>Sucursal</strong>:
                                                    <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=273&amp;SU=BCDIX"" onclick=""openw(this,600,400);return false;"" target=""_blank"">CENTRO. BP Benito Pérez Galdós</a>
&nbsp;
                                                    <span class=""linkDespliega"" style=""color:#0000FF"" onclick=""detail_copias(this);"">&#91;Desplegar ejemplares&#93;</span>
                                                </div>
                                                <table class=""dtNone"" summary=""Información de los ejemplares disponibles"">
                                                    <tr>
                                                        <th class=""newDetail""></th>
                                                        <th scope=""col"">Localización
                                                            <br>Tipo de lector
                                                        </th>
                                                        <th scope=""col"">Tipo de ejemplar</th>
                                                        <th scope=""col"">Signatura</th>
                                                        <th scope=""col"">Disponibilidad</th>
                                                        <th scope=""col"">Soporte</th>
                                                    </tr>
                                                    <tr>
                                                        <td class=""newDetail""></td>
                                                        <td>Sala adultos&nbsp;
                                                            <br>Adultos&nbsp;
                                                        </td>
                                                        <td>Prestable. Libros</td>
                                                        <td>
                                                            <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=143&amp;SIGN=N SCA nov&amp;BC=1400768728"">N SCA nov</a>&nbsp;
                                                            <br>NOVEDAD OCTUBRE&nbsp;
                                                            <br>&nbsp; 
                                                        </td>
                                                        <td>Disponible después de 02/01/2020&nbsp;</td>
                                                        <td>Libro</td>
                                                    </tr>
                                                </table>
                                                <div class=""dtSuc"">
                                                    <img src=""/biblio_publicas/imag/bullet03.gif"" alt="" ""/>
&nbsp;
                                                    <strong>Sucursal</strong>:
                                                    <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=273&amp;SU=BCDI4"" onclick=""openw(this,600,400);return false;"" target=""_blank"">CENTRO. BP Iván de Vargas</a>
&nbsp;
                                                    <span class=""linkDespliega"" style=""color:#0000FF"" onclick=""detail_copias(this);"">&#91;Desplegar ejemplares&#93;</span>
                                                </div>
                                                <table class=""dtNone"" summary=""Información de los ejemplares disponibles"">
                                                    <tr>
                                                        <th class=""newDetail""></th>
                                                        <th scope=""col"">Localización
                                                            <br>Tipo de lector
                                                        </th>
                                                        <th scope=""col"">Tipo de ejemplar</th>
                                                        <th scope=""col"">Signatura</th>
                                                        <th scope=""col"">Disponibilidad</th>
                                                        <th scope=""col"">Soporte</th>
                                                    </tr>
                                                    <tr>
                                                        <td class=""newDetail""></td>
                                                        <td>Sala adultos&nbsp;
                                                            <br>Adultos&nbsp;
                                                        </td>
                                                        <td>Prestable. Libros</td>
                                                        <td>
                                                            <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=143&amp;SIGN=N SCA nov&amp;BC=1400768730"">N SCA nov</a>&nbsp;
                                                            <br>NOVEDAD OCTUBRE&nbsp;
                                                            <br>&nbsp; 
                                                        </td>
                                                        <td>Disponible después de 09/01/2020&nbsp;</td>
                                                        <td>Libro</td>
                                                    </tr>
                                                </table>
                                                <div class=""dtSuc"">
                                                    <img src=""/biblio_publicas/imag/bullet03.gif"" alt="" ""/>
&nbsp;
                                                    <strong>Sucursal</strong>:
                                                    <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=273&amp;SU=BCDI7"" onclick=""openw(this,600,400);return false;"" target=""_blank"">CENTRO. BP Vargas LLosa</a>
&nbsp;
                                                    <span class=""linkDespliega"" style=""color:#0000FF"" onclick=""detail_copias(this);"">&#91;Desplegar ejemplares&#93;</span>
                                                </div>
                                                <table class=""dtNone"" summary=""Información de los ejemplares disponibles"">
                                                    <tr>
                                                        <th class=""newDetail""></th>
                                                        <th scope=""col"">Localización
                                                            <br>Tipo de lector
                                                        </th>
                                                        <th scope=""col"">Tipo de ejemplar</th>
                                                        <th scope=""col"">Signatura</th>
                                                        <th scope=""col"">Disponibilidad</th>
                                                        <th scope=""col"">Soporte</th>
                                                    </tr>
                                                    <tr>
                                                        <td class=""newDetail""></td>
                                                        <td>Sala adultos&nbsp;
                                                            <br>Adultos&nbsp;
                                                        </td>
                                                        <td>Prestable. Libros</td>
                                                        <td>
                                                            <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=143&amp;SIGN=N SCA nov&amp;BC=1400768733"">N SCA nov</a>&nbsp;
                                                            <br>NOVEDAD&nbsp;
                                                            <br>&nbsp; 
                                                        </td>
                                                        <td>Disponible después de 20/01/2020&nbsp;</td>
                                                        <td>Libro</td>
                                                    </tr>
                                                </table>
                                                <div class=""dtSuc"">
                                                    <img src=""/biblio_publicas/imag/bullet03.gif"" alt="" ""/>
&nbsp;
                                                    <strong>Sucursal</strong>:
                                                    <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=273&amp;SU=BCDIF"" onclick=""openw(this,600,400);return false;"" target=""_blank"">CHAMARTÍN. BP Francisco Ibañez</a>
&nbsp;
                                                    <span class=""linkDespliega"" style=""color:#0000FF"" onclick=""detail_copias(this);"">&#91;Desplegar ejemplares&#93;</span>
                                                </div>
                                                <table class=""dtNone"" summary=""Información de los ejemplares disponibles"">
                                                    <tr>
                                                        <th class=""newDetail""></th>
                                                        <th scope=""col"">Localización
                                                            <br>Tipo de lector
                                                        </th>
                                                        <th scope=""col"">Tipo de ejemplar</th>
                                                        <th scope=""col"">Signatura</th>
                                                        <th scope=""col"">Disponibilidad</th>
                                                        <th scope=""col"">Soporte</th>
                                                    </tr>
                                                    <tr>
                                                        <td class=""newDetail""></td>
                                                        <td>Sala adultos&nbsp;
                                                            <br>Adultos&nbsp;
                                                        </td>
                                                        <td>Prestable. Libros</td>
                                                        <td>
                                                            <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=143&amp;SIGN=N SCA nov&amp;BC=1400768724"">N SCA nov</a>&nbsp;
                                                            <br>&nbsp;
                                                            <br>&nbsp; 
                                                        </td>
                                                        <td>Disponible después de 27/12/2019&nbsp;</td>
                                                        <td>Libro</td>
                                                    </tr>
                                                </table>
                                                <div class=""dtSuc"">
                                                    <img src=""/biblio_publicas/imag/bullet03.gif"" alt="" ""/>
&nbsp;
                                                    <strong>Sucursal</strong>:
                                                    <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=273&amp;SU=BCDIL"" onclick=""openw(this,600,400);return false;"" target=""_blank"">CIUDAD LINEAL. BP Pablo Neruda</a>
&nbsp;
                                                    <span class=""linkDespliega"" style=""color:#0000FF"" onclick=""detail_copias(this);"">&#91;Desplegar ejemplares&#93;</span>
                                                </div>
                                                <table class=""dtNone"" summary=""Información de los ejemplares disponibles"">
                                                    <tr>
                                                        <th class=""newDetail""></th>
                                                        <th scope=""col"">Localización
                                                            <br>Tipo de lector
                                                        </th>
                                                        <th scope=""col"">Tipo de ejemplar</th>
                                                        <th scope=""col"">Signatura</th>
                                                        <th scope=""col"">Disponibilidad</th>
                                                        <th scope=""col"">Soporte</th>
                                                    </tr>
                                                    <tr>
                                                        <td class=""newDetail""></td>
                                                        <td>Sala adultos&nbsp;
                                                            <br>Adultos&nbsp;
                                                        </td>
                                                        <td>Prestable. Libros</td>
                                                        <td>
                                                            <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=143&amp;SIGN=N SCA nov&amp;BC=1400768725"">N SCA nov</a>&nbsp;
                                                            <br>NOVEDAD OCTUBRE&nbsp;
                                                            <br>&nbsp; 
                                                        </td>
                                                        <td>Disponible después de 16/01/2020&nbsp;</td>
                                                        <td>Libro</td>
                                                    </tr>
                                                </table>
                                                <div class=""dtSuc"">
                                                    <img src=""/biblio_publicas/imag/bullet03.gif"" alt="" ""/>
&nbsp;
                                                    <strong>Sucursal</strong>:
                                                    <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=273&amp;SU=BCDI8"" onclick=""openw(this,600,400);return false;"" target=""_blank"">HORTALEZA. BP María Lejárraga</a>
&nbsp;
                                                    <span class=""linkDespliega"" style=""color:#0000FF"" onclick=""detail_copias(this);"">&#91;Desplegar ejemplares&#93;</span>
                                                </div>
                                                <table class=""dtNone"" summary=""Información de los ejemplares disponibles"">
                                                    <tr>
                                                        <th class=""newDetail""></th>
                                                        <th scope=""col"">Localización
                                                            <br>Tipo de lector
                                                        </th>
                                                        <th scope=""col"">Tipo de ejemplar</th>
                                                        <th scope=""col"">Signatura</th>
                                                        <th scope=""col"">Disponibilidad</th>
                                                        <th scope=""col"">Soporte</th>
                                                    </tr>
                                                    <tr>
                                                        <td class=""newDetail""></td>
                                                        <td>Sala adultos&nbsp;
                                                            <br>Adultos&nbsp;
                                                        </td>
                                                        <td>Prestable. Libros</td>
                                                        <td>
                                                            <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=143&amp;SIGN=N SCA nov&amp;BC=1400768734"">N SCA nov</a>&nbsp;
                                                            <br>&nbsp;
                                                            <br>&nbsp; 
                                                        </td>
                                                        <td>Disponible después de 11/01/2020&nbsp;</td>
                                                        <td>Libro</td>
                                                    </tr>
                                                </table>
                                                <div class=""dtSuc"">
                                                    <img src=""/biblio_publicas/imag/bullet03.gif"" alt="" ""/>
&nbsp;
                                                    <strong>Sucursal</strong>:
                                                    <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=273&amp;SU=BCDI3"" onclick=""openw(this,600,400);return false;"" target=""_blank"">LATINA. BP Ángel González</a>
&nbsp;
                                                    <span class=""linkDespliega"" style=""color:#0000FF"" onclick=""detail_copias(this);"">&#91;Desplegar ejemplares&#93;</span>
                                                </div>
                                                <table class=""dtNone"" summary=""Información de los ejemplares disponibles"">
                                                    <tr>
                                                        <th class=""newDetail""></th>
                                                        <th scope=""col"">Localización
                                                            <br>Tipo de lector
                                                        </th>
                                                        <th scope=""col"">Tipo de ejemplar</th>
                                                        <th scope=""col"">Signatura</th>
                                                        <th scope=""col"">Disponibilidad</th>
                                                        <th scope=""col"">Soporte</th>
                                                    </tr>
                                                    <tr>
                                                        <td class=""newDetail""></td>
                                                        <td>Sala adultos&nbsp;
                                                            <br>Adultos&nbsp;
                                                        </td>
                                                        <td>Prestable. Libros</td>
                                                        <td>
                                                            <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=143&amp;SIGN=N SCA nov&amp;BC=1400768729"">N SCA nov</a>&nbsp;
                                                            <br>NOVEDAD&nbsp;
                                                            <br>&nbsp; 
                                                        </td>
                                                        <td>Disponible después de 10/01/2020&nbsp;</td>
                                                        <td>Libro</td>
                                                    </tr>
                                                </table>
                                                <div class=""dtSuc"">
                                                    <img src=""/biblio_publicas/imag/bullet03.gif"" alt="" ""/>
&nbsp;
                                                    <strong>Sucursal</strong>:
                                                    <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=273&amp;SU=BCDI5"" onclick=""openw(this,600,400);return false;"" target=""_blank"">RETIRO. BP Eugenio Trías</a>
&nbsp;
                                                    <span class=""linkDespliega"" style=""color:#0000FF"" onclick=""detail_copias(this);"">&#91;Desplegar ejemplares&#93;</span>
                                                </div>
                                                <table class=""dtNone"" summary=""Información de los ejemplares disponibles"">
                                                    <tr>
                                                        <th class=""newDetail""></th>
                                                        <th scope=""col"">Localización
                                                            <br>Tipo de lector
                                                        </th>
                                                        <th scope=""col"">Tipo de ejemplar</th>
                                                        <th scope=""col"">Signatura</th>
                                                        <th scope=""col"">Disponibilidad</th>
                                                        <th scope=""col"">Soporte</th>
                                                    </tr>
                                                    <tr>
                                                        <td class=""newDetail""></td>
                                                        <td>Sala adultos&nbsp;
                                                            <br>Adultos&nbsp;
                                                        </td>
                                                        <td>Prestable. Libros</td>
                                                        <td>
                                                            <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=143&amp;SIGN=N SCA nov&amp;BC=1400768731"">N SCA nov</a>&nbsp;
                                                            <br>&nbsp;
                                                            <br>&nbsp; 
                                                        </td>
                                                        <td>Disponible después de 02/01/2020&nbsp;</td>
                                                        <td>Libro</td>
                                                    </tr>
                                                    <tr>
                                                        <td class=""newDetail""></td>
                                                        <td>Sala adultos&nbsp;
                                                            <br>Adultos&nbsp;
                                                        </td>
                                                        <td>Prestable. Libros</td>
                                                        <td>
                                                            <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=143&amp;SIGN=N SCA nov&amp;BC=1400724631"">N SCA nov</a>&nbsp;
                                                            <br>&nbsp;
                                                            <br>&nbsp; 
                                                        </td>
                                                        <td>Disponible después de 03/01/2020&nbsp;</td>
                                                        <td>Libro</td>
                                                    </tr>
                                                </table>
                                                <div class=""dtSuc"">
                                                    <img src=""/biblio_publicas/imag/bullet03.gif"" alt="" ""/>
&nbsp;
                                                    <strong>Sucursal</strong>:
                                                    <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=273&amp;SU=BCDIN"" onclick=""openw(this,600,400);return false;"" target=""_blank"">SALAMANCA. BP Buenavista</a>
&nbsp;
                                                    <span class=""linkDespliega"" style=""color:#0000FF"" onclick=""detail_copias(this);"">&#91;Desplegar ejemplares&#93;</span>
                                                </div>
                                                <table class=""dtNone"" summary=""Información de los ejemplares disponibles"">
                                                    <tr>
                                                        <th class=""newDetail""></th>
                                                        <th scope=""col"">Localización
                                                            <br>Tipo de lector
                                                        </th>
                                                        <th scope=""col"">Tipo de ejemplar</th>
                                                        <th scope=""col"">Signatura</th>
                                                        <th scope=""col"">Disponibilidad</th>
                                                        <th scope=""col"">Soporte</th>
                                                    </tr>
                                                    <tr>
                                                        <td class=""newDetail""></td>
                                                        <td>Sala adultos&nbsp;
                                                            <br>Adultos&nbsp;
                                                        </td>
                                                        <td>Prestable. Libros</td>
                                                        <td>
                                                            <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=143&amp;SIGN=N SCA nov&amp;BC=1400768726"">N SCA nov</a>&nbsp;
                                                            <br>NOVEDAD&nbsp;
                                                            <br>&nbsp; 
                                                        </td>
                                                        <td>Disponible después de 20/01/2020&nbsp;</td>
                                                        <td>Libro</td>
                                                    </tr>
                                                </table>
                                                <div class=""dtSuc"">
                                                    <img src=""/biblio_publicas/imag/bullet03.gif"" alt="" ""/>
&nbsp;
                                                    <strong>Sucursal</strong>:
                                                    <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=273&amp;SU=BCDIW"" onclick=""openw(this,600,400);return false;"" target=""_blank"">SAN BLAS. BP José Hierro</a>
&nbsp;
                                                    <span class=""linkDespliega"" style=""color:#0000FF"" onclick=""detail_copias(this);"">&#91;Desplegar ejemplares&#93;</span>
                                                </div>
                                                <table class=""dtNone"" summary=""Información de los ejemplares disponibles"">
                                                    <tr>
                                                        <th class=""newDetail""></th>
                                                        <th scope=""col"">Localización
                                                            <br>Tipo de lector
                                                        </th>
                                                        <th scope=""col"">Tipo de ejemplar</th>
                                                        <th scope=""col"">Signatura</th>
                                                        <th scope=""col"">Disponibilidad</th>
                                                        <th scope=""col"">Soporte</th>
                                                    </tr>
                                                    <tr>
                                                        <td class=""newDetail""></td>
                                                        <td>Sala adultos&nbsp;
                                                            <br>Adultos&nbsp;
                                                        </td>
                                                        <td>Prestable. Libros</td>
                                                        <td>
                                                            <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=143&amp;SIGN=N SCA nov&amp;BC=1400768727"">N SCA nov</a>&nbsp;
                                                            <br>NOVEDAD&nbsp;
                                                            <br>&nbsp; 
                                                        </td>
                                                        <td>Disponible&nbsp;</td>
                                                        <td>Libro</td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <br/>
                                            <div class=""detmain detbib"">
                                                <strong>Biblioteca</strong>:
                                                <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=271&amp;BI=RBMMEJ"" onclick=""openw(this,600,400);return false;"" target=""_blank"">MEJORADA DEL CAMPO. Biblioteca Municipal de Mejorada del Campo</a>
                                                <br/>
                                                <div class=""dtSuc"">
                                                    <img src=""/biblio_publicas/imag/bullet03.gif"" alt="" ""/>
&nbsp;
                                                    <strong>Sucursal</strong>:
                                                    <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=273&amp;SU=BMMEJ1"" onclick=""openw(this,600,400);return false;"" target=""_blank"">Biblioteca Municipal Hans Christian Andersen</a>
&nbsp;
                                                    <span class=""linkDespliega"" style=""color:#0000FF"" onclick=""detail_copias(this);"">&#91;Desplegar ejemplares&#93;</span>
                                                </div>
                                                <table class=""dtNone"" summary=""Información de los ejemplares disponibles"">
                                                    <tr>
                                                        <th class=""newDetail""></th>
                                                        <th scope=""col"">Localización
                                                            <br>Tipo de lector
                                                        </th>
                                                        <th scope=""col"">Tipo de ejemplar</th>
                                                        <th scope=""col"">Signatura</th>
                                                        <th scope=""col"">Disponibilidad</th>
                                                        <th scope=""col"">Soporte</th>
                                                    </tr>
                                                    <tr>
                                                        <td class=""newDetail""></td>
                                                        <td>Sala adultos&nbsp;
                                                            <br>Adultos&nbsp;
                                                        </td>
                                                        <td>Prestable. Libros</td>
                                                        <td>
                                                            <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=143&amp;SIGN=N SCA nov&amp;BC=1500266318"">N SCA nov</a>&nbsp;
                                                            <br>Adultos&nbsp;
                                                            <br>&nbsp; 
                                                        </td>
                                                        <td>Disponible&nbsp;</td>
                                                        <td>Libro</td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <br/>
                                            <div class=""detmain detbib"">
                                                <strong>Biblioteca</strong>:
                                                <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=271&amp;BI=RBMSOT"" onclick=""openw(this,600,400);return false;"" target=""_blank"">SOTO DEL REAL. Biblioteca Municipal de Soto de Real</a>
                                                <br/>
                                                <div class=""dtSuc"">
                                                    <img src=""/biblio_publicas/imag/bullet03.gif"" alt="" ""/>
&nbsp;
                                                    <strong>Sucursal</strong>:
                                                    <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=273&amp;SU=BMSOT1"" onclick=""openw(this,600,400);return false;"" target=""_blank"">Biblioteca Municipal Pedro de Lorenzo</a>
&nbsp;
                                                    <span class=""linkDespliega"" style=""color:#0000FF"" onclick=""detail_copias(this);"">&#91;Desplegar ejemplares&#93;</span>
                                                </div>
                                                <table class=""dtNone"" summary=""Información de los ejemplares disponibles"">
                                                    <tr>
                                                        <th class=""newDetail""></th>
                                                        <th scope=""col"">Localización
                                                            <br>Tipo de lector
                                                        </th>
                                                        <th scope=""col"">Tipo de ejemplar</th>
                                                        <th scope=""col"">Signatura</th>
                                                        <th scope=""col"">Disponibilidad</th>
                                                        <th scope=""col"">Soporte</th>
                                                    </tr>
                                                    <tr>
                                                        <td class=""newDetail""></td>
                                                        <td>Sala adultos&nbsp;
                                                            <br>Adultos&nbsp;
                                                        </td>
                                                        <td>Prestable. Libros</td>
                                                        <td>
                                                            <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=143&amp;SIGN=N SCA nov&amp;BC=1500269979"">N SCA nov</a>&nbsp;
                                                            <br>&nbsp;
                                                            <br>&nbsp; 
                                                        </td>
                                                        <td>Disponible&nbsp;</td>
                                                        <td>Libro</td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <br/>
                                        </div>
                                        <div id=""ejedis"" class=""dvNone"">
                                            <div>Nº de ejemplares disponibles: 
                                                <strong>3</strong>&nbsp;&nbsp;/&nbsp;&nbsp;Nº de veces prestado:
                                                <strong>40</strong>
                                            </div>
                                        </div>
                                        <span style=""display:none"">
                                            <select onchange=""ChgSubcat();"" id=""subcat"" name=""subcat"">
                                                <option value=""/"">Todas las bibliotecas</option>
                                                <option value=""BR"">Biblioteca Regional</option>
                                                <option value=""ESCOL"">Bibliotecas escolares</option>
                                                <option value=""EXBIB"">Extensión bibliotecaria</option>
                                                <option value=""EXBIB/MUNI"">&nbsp;&nbsp;&gt;Servicios de Extensión Bibliotecaria</option>
                                                <option value=""EXBIB/MUNI/BB01"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Bibliobuses</option>
                                                <option value=""EXBIB/MUNI/BMETRO"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Bibliometro</option>
                                                <option value=""EXBIB/MUNI/BRED"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Bibliored</option>
                                                <option value=""EXBIB/MUNI/BP25"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Telebiblioteca</option>
                                                <option value=""BPCM"">Redes de Bibliotecas Públicas</option>
                                                <option value=""BPCM/RBMALM"">&nbsp;&nbsp;&gt;ALAMO. Biblioteca Municipal de El Álamo</option>
                                                <option value=""BPCM/RBMALM/BMALM1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal de El Álamo</option>
                                                <option value=""BPCM/RBMALC"">&nbsp;&nbsp;&gt;ALCALÁ DE HENARES. Bibliotecas Municipales Alcalá</option>
                                                <option value=""BPCM/RBMALC/BMALC1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B.P.M. Cardenal Cisneros</option>
                                                <option value=""BPCM/RBMALC/BMALC6"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B.P.M. José Chacón</option>
                                                <option value=""BPCM/RBMALC/BMALC8"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B.P.M. La Galatea</option>
                                                <option value=""BPCM/RBMALC/BMALC3"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B.P.M. María Moliner</option>
                                                <option value=""BPCM/RBMALC/BMALC7"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B.P.M. María Zambrano</option>
                                                <option value=""BPCM/RBMALC/BMALC2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B.P.M. Pío Baroja</option>
                                                <option value=""BPCM/RBMALC/BMALC5"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B.P.M. Rafael Alberti</option>
                                                <option value=""BPCM/RBMALC/BMALC4"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B.P.M. Rosa Chacel</option>
                                                <option value=""BPCM/RBMALB"">&nbsp;&nbsp;&gt;ALCOBENDAS. Mediatecas de Alcobendas</option>
                                                <option value=""BPCM/RBMALB/BMALB3"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Mediateca Anabel Segura</option>
                                                <option value=""BPCM/RBMALB/BMALB2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Mediateca Centro de Arte</option>
                                                <option value=""BPCM/RBMALB/BMALB4"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Mediateca Miguel Delibes</option>
                                                <option value=""BPCM/RBMALB/BMALB1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Mediateca Pablo Iglesias</option>
                                                <option value=""BPCM/RBMALR"">&nbsp;&nbsp;&gt;ALCORCÓN. Bibliotecas Municipales de Alcorcón</option>
                                                <option value=""BPCM/RBMALR/BMALR5"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Ciudad de Nejapa</option>
                                                <option value=""BPCM/RBMALR/BMALR1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca El Parque</option>
                                                <option value=""BPCM/RBMALR/BMALR4"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca El Pinar</option>
                                                <option value=""BPCM/RBMALR/BMALR7"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Fuente Cisneros</option>
                                                <option value=""BPCM/RBMALR/BMALR3"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Joaquín Vilumbrales</option>
                                                <option value=""BPCM/RBMALR/BMALR2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca José Hierro</option>
                                                <option value=""BPCM/RBMALR/BMALR6"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Miguel Delibes</option>
                                                <option value=""BPCM/RBMALG"">&nbsp;&nbsp;&gt;ALGETE. Biblioteca Municipal de Algete</option>
                                                <option value=""BPCM/RBMALG/BMALG1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Miguel de Cervantes</option>
                                                <option value=""BPCM/RBMALP"">&nbsp;&nbsp;&gt;ALPEDRETE. Biblioteca Municipal de Alpedrete</option>
                                                <option value=""BPCM/RBMALP/BMALP1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal de Alpedrete</option>
                                                <option value=""BPCM/RBMARA"">&nbsp;&nbsp;&gt;ARANJUEZ. Biblioteca Municipal de Aranjuez</option>
                                                <option value=""BPCM/RBMARA/BMARA1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Álvarez de Quindós</option>
                                                <option value=""BPCM/RBMARG"">&nbsp;&nbsp;&gt;ARGANDA DEL REY. Bibliotecas Municipales de Arganda del Rey</option>
                                                <option value=""BPCM/RBMARG/BMARG2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal La Poveda</option>
                                                <option value=""BPCM/RBMARG/BMARG1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Pablo Neruda</option>
                                                <option value=""BPCM/RBMARR"">&nbsp;&nbsp;&gt;ARROYOMOLINOS. Biblioteca Municipal de Arroyomolinos</option>
                                                <option value=""BPCM/RBMARR/BMARR1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal de Arroyomolinos</option>
                                                <option value=""BPCM/RBMBOA"">&nbsp;&nbsp;&gt;BOADILLA DEL MONTE. Bibliotecas Municipales de Boadilla del Monte</option>
                                                <option value=""BPCM/RBMBOA/BMBOA1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal de Boadilla del Monte</option>
                                                <option value=""BPCM/RBMBOA/BMBOA2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal José Ortega y Gasset</option>
                                                <option value=""BPCM/RBMBRU"">&nbsp;&nbsp;&gt;BRUNETE. Biblioteca Municipal de Brunete</option>
                                                <option value=""BPCM/RBMBRU/BMBRU1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Dulce Chacón</option>
                                                <option value=""BPCM/RBMCBR"">&nbsp;&nbsp;&gt;CABRERA. Biblioteca Municipal de La Cabrera</option>
                                                <option value=""BPCM/RBMCBR/BMCBR1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca del Centro Comarcal de Humanidades Cardenal Gonzaga. Sierra Norte</option>
                                                <option value=""BPCM/RBMCAE"">&nbsp;&nbsp;&gt;CAMARMA DE ESTERUELAS. Biblioteca Municipal de Camarma de Esteruelas</option>
                                                <option value=""BPCM/RBMCAE/BMCAE1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal de Camarma de Esteruelas</option>
                                                <option value=""BPCM/RBMCHP"">&nbsp;&nbsp;&gt;CHAPINERÍA. Biblioteca Municipal de Chapinería</option>
                                                <option value=""BPCM/RBMCHP/BMCHP1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal de Chapinería</option>
                                                <option value=""BPCM/RBMCHI"">&nbsp;&nbsp;&gt;CHINCHÓN. Biblioteca Municipal de Chinchón</option>
                                                <option value=""BPCM/RBMCHI/BMCHI1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Petra Ramírez</option>
                                                <option value=""BPCM/RBMCIE"">&nbsp;&nbsp;&gt;CIEMPOZUELOS. Biblioteca Municipal de Ciempozuelos</option>
                                                <option value=""BPCM/RBMCIE/BMCIE1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal de Ciempozuelos</option>
                                                <option value=""BPCM/RBMCOV"">&nbsp;&nbsp;&gt;COLLADO VILLALBA. Biblioteca Municipales de Collado Villalba</option>
                                                <option value=""BPCM/RBMCOV/BMCOV2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Miguel Hernández</option>
                                                <option value=""BPCM/RBMCOV/BMCOV1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Sancho Panza</option>
                                                <option value=""BPCM/RBMCVI"">&nbsp;&nbsp;&gt;COLMENAR VIEJO. Bibliotecas Municipales de Colmenar Viejo</option>
                                                <option value=""BPCM/RBMCVI/BMCVI1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Miguel de Cervantes</option>
                                                <option value=""BPCM/RBMCVI/BMCVI2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Pablo Ruiz Picasso</option>
                                                <option value=""BPCM/RBMCVI/BMCVI3"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Vargas Llosa</option>
                                                <option value=""BPCM/RBMCOS"">&nbsp;&nbsp;&gt;COSLADA. Bibliotecas Municipales de Coslada</option>
                                                <option value=""BPCM/RBMCOS/BMCOS1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Central</option>
                                                <option value=""BPCM/RBMCOS/BMCOS2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal La Jaramilla</option>
                                                <option value=""BPCM/RBMELE"">&nbsp;&nbsp;&gt;EL ESCORIAL. Biblioteca Municipal de El Escorial</option>
                                                <option value=""BPCM/RBMELE/BMELE1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal de El Escorial</option>
                                                <option value=""BPCM/RBMELM"">&nbsp;&nbsp;&gt;EL MOLAR. Biblioteca Municipal de El Molar</option>
                                                <option value=""BPCM/RBMELM/BMELM1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Blanca de Igual</option>
                                                <option value=""BPCM/RBMFSZ"">&nbsp;&nbsp;&gt;FUENTE EL SAZ. Biblioteca Municipal de Fuente el Saz de Jarama</option>
                                                <option value=""BPCM/RBMFSZ/BMFSZ1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal El Pilar</option>
                                                <option value=""BPCM/RBMFNT"">&nbsp;&nbsp;&gt;FUENTIDUEÑA DE TAJO. Biblioteca Municipal de Fuentidueña de Tajo</option>
                                                <option value=""BPCM/RBMFNT/BMFNT1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Luis Cubero</option>
                                                <option value=""BPCM/RBMGAL"">&nbsp;&nbsp;&gt;GALAPAGAR. Biblioteca Municipal de Galapagar</option>
                                                <option value=""BPCM/RBMGAL/BMGAL1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Ricardo León</option>
                                                <option value=""BPCM/RBMGET"">&nbsp;&nbsp;&gt;GETAFE. Red de Bibliotecas Municipales de Getafe</option>
                                                <option value=""BPCM/RBMGET/BMGET5"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Almudena Grandes</option>
                                                <option value=""BPCM/RBMGET/BMGET4"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Carmen Martín Gaite</option>
                                                <option value=""BPCM/RBMGET/BMGET1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Jorge Luis Borges</option>
                                                <option value=""BPCM/RBMGET/BMGET3"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;José Luis Sampedro</option>
                                                <option value=""BPCM/RBMGET/BMGET2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Ricardo de la Vega</option>
                                                <option value=""BPCM/RBMGRI"">&nbsp;&nbsp;&gt;GRIÑÓN. Biblioteca Municipal de Griñón</option>
                                                <option value=""BPCM/RBMGRI/BMGRI1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Casa de la Cultura</option>
                                                <option value=""BPCM/RBMGDR"">&nbsp;&nbsp;&gt;GUADARRAMA. Biblioteca Municipal de Guadarrama</option>
                                                <option value=""BPCM/RBMGDR/BMGDR1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Arcipreste de Hita</option>
                                                <option value=""BPCM/RBMHUM"">&nbsp;&nbsp;&gt;HUMANES DE MADRID. Biblioteca Municipal de Humanes de Madrid</option>
                                                <option value=""BPCM/RBMHUM/BMHUM1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Lorenzo Silva</option>
                                                <option value=""BPCM/BPM"">&nbsp;&nbsp;&gt;MADRID. Bibliotecas Públicas</option>
                                                <option value=""BPCM/BPM/BCDIU"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;ARGANZUELA. BP Pío Baroja</option>
                                                <option value=""BPCM/BPM/BCDIG"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;BARAJAS. BP Gloria Fuertes</option>
                                                <option value=""BPCM/BPM/BCDIB"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CARABANCHEL. BP Ana Mª Matute</option>
                                                <option value=""BPCM/BPM/BCDIM"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CARABANCHEL. BP La Chata</option>
                                                <option value=""BPCM/BPM/BP04"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CARABANCHEL. BP Luis Rosales</option>
                                                <option value=""BPCM/BPM/BCDIX"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CENTRO. BP Benito Pérez Galdós</option>
                                                <option value=""BPCM/BPM/BCDI4"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CENTRO. BP Iván de Vargas</option>
                                                <option value=""BPCM/BPM/BP06"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CENTRO. BP Pedro Salinas</option>
                                                <option value=""BPCM/BPM/BCDI7"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CENTRO. BP Vargas LLosa</option>
                                                <option value=""BPCM/BPM/BCDIZ"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CHAMARTÍN. BP Dámaso Alonso</option>
                                                <option value=""BPCM/BPM/BCDIF"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CHAMARTÍN. BP Francisco Ibañez</option>
                                                <option value=""BPCM/BPM/BP05"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CHAMBERÍ. BP José Luis Sampedro</option>
                                                <option value=""BPCM/BPM/BP17"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CHAMBERÍ. BP Ruiz Egea</option>
                                                <option value=""BPCM/BPM/BCDIS"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CIUDAD LINEAL. BP Ciudad Lineal</option>
                                                <option value=""BPCM/BPM/BCDID"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CIUDAD LINEAL. BP La Elipa</option>
                                                <option value=""BPCM/BPM/BCDIL"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;CIUDAD LINEAL. BP Pablo Neruda</option>
                                                <option value=""BPCM/BPM/BCDIR"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;FUENCARRAL-EL PARDO. BP José Saramago</option>
                                                <option value=""BPCM/BPM/BP08"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;FUENCARRAL-EL PARDO. BP Rafael Alberti</option>
                                                <option value=""BPCM/BPM/BP09"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;HORTALEZA. BP Hortaleza</option>
                                                <option value=""BPCM/BPM/BCDIA"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;HORTALEZA. BP Huerta de la Salud</option>
                                                <option value=""BPCM/BPM/BCDI8"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;HORTALEZA. BP María Lejárraga</option>
                                                <option value=""BPCM/BPM/BCDIK"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;LATINA. BP Aluche</option>
                                                <option value=""BPCM/BPM/BCDI3"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;LATINA. BP Ángel González</option>
                                                <option value=""BPCM/BPM/BP10"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;LATINA. BP Antonio Mingote</option>
                                                <option value=""BPCM/BPM/BP02"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;MONCLOA-ARAVACA. BP Acuña</option>
                                                <option value=""BPCM/BPM/BCDIH"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;MORATALAZ. BP Miguel Delibes</option>
                                                <option value=""BPCM/BPM/BP13"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;MORATALAZ. BP Moratalaz</option>
                                                <option value=""BPCM/BPM/BP19"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;PUENTE DE VALLECAS. BP Miguel Hernández</option>
                                                <option value=""BPCM/BPM/BP14"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;PUENTE DE VALLECAS. BP Paco Rabal</option>
                                                <option value=""BPCM/BPM/BCDIJ"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;PUENTE DE VALLECAS. BP Portazgo</option>
                                                <option value=""BPCM/BPM/BCDIQ"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;PUENTE DE VALLECAS. BP Pozo Tío Raimundo</option>
                                                <option value=""BPCM/BPM/BCDIV"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;PUENTE DE VALLECAS. BP Vallecas</option>
                                                <option value=""BPCM/BPM/BP16"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;RETIRO. BP Elena Fortún</option>
                                                <option value=""BPCM/BPM/BCDI5"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;RETIRO. BP Eugenio Trías</option>
                                                <option value=""BPCM/BPM/BCDIN"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;SALAMANCA. BP Buenavista</option>
                                                <option value=""BPCM/BPM/BCDIC"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;SAN BLAS. BP Canillejas</option>
                                                <option value=""BPCM/BPM/BCDIW"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;SAN BLAS. BP José Hierro</option>
                                                <option value=""BPCM/BPM/BCDIO"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;SAN BLAS. BP San Blas</option>
                                                <option value=""BPCM/BPM/BCDIT"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;TETUÁN. BP María Zambrano</option>
                                                <option value=""BPCM/BPM/BCDI2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;TETUÁN. BP Vázquez Montalbán</option>
                                                <option value=""BPCM/BPM/BCDII"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;USERA. BP García Márquez</option>
                                                <option value=""BPCM/BPM/BP18"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;USERA. BP José Hierro</option>
                                                <option value=""BPCM/BPM/BCDIP"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;VICÁLVARO. BP Francisco Ayala</option>
                                                <option value=""BPCM/BPM/BCDIE"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;VICÁLVARO. BP Vicálvaro</option>
                                                <option value=""BPCM/BPM/BCDIY"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;VILLA DE VALLECAS. BP Gerardo Diego</option>
                                                <option value=""BPCM/BPM/BP20"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;VILLA DE VALLECAS. BP Luis Martín Santos</option>
                                                <option value=""BPCM/BPM/BP21"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;VILLAVERDE. BP María Moliner</option>
                                                <option value=""BPCM/RBMMAJ"">&nbsp;&nbsp;&gt;MAJADAHONDA. Biblioteca Municipal de Majadahonda</option>
                                                <option value=""BPCM/RBMMAJ/BMMAJ1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Francisco Umbral</option>
                                                <option value=""BPCM/RBMMEC"">&nbsp;&nbsp;&gt;MECO. Biblioteca Municipal de Meco</option>
                                                <option value=""BPCM/RBMMEC/BMMEC1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal de Meco</option>
                                                <option value=""BPCM/RBMMEJ"">&nbsp;&nbsp;&gt;MEJORADA DEL CAMPO. Biblioteca Municipal de Mejorada del Campo</option>
                                                <option value=""BPCM/RBMMEJ/BMMEJ1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Hans Christian Andersen</option>
                                                <option value=""BPCM/RBMMRZ"">&nbsp;&nbsp;&gt;MORALZARZAL. Biblioteca Municipal de Moralzarzal</option>
                                                <option value=""BPCM/RBMMRZ/BMMRZ1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Casa Grande</option>
                                                <option value=""BPCM/RBMMOS"">&nbsp;&nbsp;&gt;MÓSTOLES. Bibliotecas Municipales</option>
                                                <option value=""BPCM/RBMMOS/BMMOS4"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B. Móstoles CALEIDOSCOPIO</option>
                                                <option value=""BPCM/RBMMOS/BMMOS1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B. Móstoles CENTRAL</option>
                                                <option value=""BPCM/RBMMOS/BMMOS6"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B. Móstoles COIMBRA</option>
                                                <option value=""BPCM/RBMMOS/BMMOS2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B. Móstoles EL SOTO</option>
                                                <option value=""BPCM/RBMMOS/BMMOS3"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B. Móstoles JOAN MIRÓ</option>
                                                <option value=""BPCM/RBMMOS/BMMOS5"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B. Móstoles NORTE-UNIVERSIDAD</option>
                                                <option value=""BPCM/RBMNAL"">&nbsp;&nbsp;&gt;NAVALCARNERO. Biblioteca Municipal de Navalcarnero</option>
                                                <option value=""BPCM/RBMNAL/BMNAL1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal José María Bausá</option>
                                                <option value=""BPCM/RBMPAJ"">&nbsp;&nbsp;&gt;PARACUELLOS DE JARAMA. Biblioteca Municipal de Paracuellos de Jarama</option>
                                                <option value=""BPCM/RBMPAJ/BMPAJ1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal de Paracuellos de Jarama</option>
                                                <option value=""BPCM/RBMPAR"">&nbsp;&nbsp;&gt;PARLA. Bibliotecas Municipales de Parla</option>
                                                <option value=""BPCM/RBMPAR/BMPAR1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Gloria Fuertes</option>
                                                <option value=""BPCM/RBMPAR/BMPAR2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Isaac Albéniz</option>
                                                <option value=""BPCM/RBMPED"">&nbsp;&nbsp;&gt;PEDREZUELA. Biblioteca Municipal</option>
                                                <option value=""BPCM/RBMPED/BMPED1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal de Pedrezuela</option>
                                                <option value=""BPCM/RBMPNT"">&nbsp;&nbsp;&gt;PINTO. Bibliotecas Municipales de Pinto</option>
                                                <option value=""BPCM/RBMPNT/BMPNT1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Casa de la Cadena</option>
                                                <option value=""BPCM/RBMPNT/BMPNT2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Javier Lapeña</option>
                                                <option value=""BPCM/RBMRVM"">&nbsp;&nbsp;&gt;RIVAS VACIAMADRID. Bibliotecas Municipales de Rivas Vaciamadrid</option>
                                                <option value=""BPCM/RBMRVM/BMRVM3"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B.M. Casco Antiguo</option>
                                                <option value=""BPCM/RBMRVM/BMRVM1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B.M. Federico García Lorca</option>
                                                <option value=""BPCM/RBMRVM/BMRVM4"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B.M. Gloria Fuertes</option>
                                                <option value=""BPCM/RBMRVM/BMRVM2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;B.M. José Saramago</option>
                                                <option value=""BPCM/RBMROB"">&nbsp;&nbsp;&gt;ROBLEDO DE CHAVELA. Biblioteca Municipal de Robledo de Chavela</option>
                                                <option value=""BPCM/RBMROB/BMROB1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Antoniorrobles</option>
                                                <option value=""BPCM/RBMSFH"">&nbsp;&nbsp;&gt;SAN FERNANDO DE HENARES. Bibliotecas Municipales de San Fernando de Henares</option>
                                                <option value=""BPCM/RBMSFH/BMSFH2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Mario Benedetti</option>
                                                <option value=""BPCM/RBMSFH/BMSFH1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Rafael Alberti</option>
                                                <option value=""BPCM/RBMSLE"">&nbsp;&nbsp;&gt;SAN LORENZO DE EL ESCORIAL. Biblioteca Municipal de San Lorenzo de El Escorial</option>
                                                <option value=""BPCM/RBMSLE/BMSLE1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Pedro Antonio de Alarcón</option>
                                                <option value=""BPCM/RBMSMV"">&nbsp;&nbsp;&gt;SAN MARTÍN DE LA VEGA. Biblioteca Municipal de San Martín de la Vega</option>
                                                <option value=""BPCM/RBMSMV/BMSMV1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Dos de Mayo</option>
                                                <option value=""BPCM/RBMSMI"">&nbsp;&nbsp;&gt;SAN MARTÍN DE VALDEIGLESIAS. Biblioteca Municipal de San Martín de Valdeiglesias</option>
                                                <option value=""BPCM/RBMSMI/BMSMI1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Miguel Hernández</option>
                                                <option value=""BPCM/RBMSSR"">&nbsp;&nbsp;&gt;SAN SEBASTIÁN DE LOS REYES. Bibliotecas Municipales de S. Sebastián de los Reyes</option>
                                                <option value=""BPCM/RBMSSR/BMSSR2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Claudio Rodríguez</option>
                                                <option value=""BPCM/RBMSSR/BMSSR1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Marcos Ana</option>
                                                <option value=""BPCM/RBMSSR/BMSSR3"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Plaza de la Iglesia</option>
                                                <option value=""BPCM/RBMSEV"">&nbsp;&nbsp;&gt;SEVILLA LA NUEVA. Biblioteca Municipal de Sevilla la Nueva</option>
                                                <option value=""BPCM/RBMSEV/BMSEV1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal José Ángel Mañas</option>
                                                <option value=""BPCM/RBMSOT"">&nbsp;&nbsp;&gt;SOTO DEL REAL. Biblioteca Municipal de Soto de Real</option>
                                                <option value=""BPCM/RBMSOT/BMSOT1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Pedro de Lorenzo</option>
                                                <option value=""BPCM/RBMTAL"">&nbsp;&nbsp;&gt;TALAMANCA DE JARAMA. Biblioteca Municipal de Talamanca de Jarama</option>
                                                <option value=""BPCM/RBMTAL/BMTAL1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal de Talamanca de Jarama</option>
                                                <option value=""BPCM/RBMTOR"">&nbsp;&nbsp;&gt;TORREJÓN DE ARDOZ. Bibliotecas Municipales de Torrejón de Ardoz</option>
                                                <option value=""BPCM/RBMTOR/BMTOR3"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Enrique Tierno Galván</option>
                                                <option value=""BPCM/RBMTOR/BMTOR2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Federico García-Lorca</option>
                                                <option value=""BPCM/RBMTOR/BMTOR1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Gabriel Celaya</option>
                                                <option value=""BPCM/RBMTOR/BMTOR4"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca ""La Isla Misteriosa""</option>
                                                <option value=""BPCM/RBMTRC"">&nbsp;&nbsp;&gt;TORREJÓN DE LA CALZADA. Biblioteca Municipal</option>
                                                <option value=""BPCM/RBMTRC/BMTRC1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal María Moliner</option>
                                                <option value=""BPCM/RBMTRG"">&nbsp;&nbsp;&gt;TORRELAGUNA. Biblioteca Municipal</option>
                                                <option value=""BPCM/RBMTRG/BMTRG1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Juan de Mena</option>
                                                <option value=""BPCM/RBMTRL"">&nbsp;&nbsp;&gt;TORRELODONES. Bibliotecas Municipales de Torrelodones</option>
                                                <option value=""BPCM/RBMTRL/BMTRL2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Casa de la Cultura</option>
                                                <option value=""BPCM/RBMTRL/BMTRL1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal José de Vicente Muñoz</option>
                                                <option value=""BPCM/RBMTRE"">&nbsp;&nbsp;&gt;TRES CANTOS. Bibliotecas Municipales Tres Cantos</option>
                                                <option value=""BPCM/RBMTRE/BMTRE2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Fundación Caja Madrid</option>
                                                <option value=""BPCM/RBMTRE/BMTRE1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Lope de Vega</option>
                                                <option value=""BPCM/RBMVDM"">&nbsp;&nbsp;&gt;VALDEMORILLO. Biblioteca Municipal de Valdemorillo</option>
                                                <option value=""BPCM/RBMVDM/BMVDM1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal María Giralt</option>
                                                <option value=""BPCM/RBMVDE"">&nbsp;&nbsp;&gt;VALDEMORO. Bibliotecas Municipales de Valdemoro</option>
                                                <option value=""BPCM/RBMVDE/BMVDE1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Ana María Matute</option>
                                                <option value=""BPCM/RBMVDE/BMVDE3"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Centro de la Estación</option>
                                                <option value=""BPCM/RBMVDE/BMVDE2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Juan Prado</option>
                                                <option value=""BPCM/RBMVEL"">&nbsp;&nbsp;&gt;VELILLA DE SAN ANTONIO. Biblioteca Municipal de Velilla de San Antonio</option>
                                                <option value=""BPCM/RBMVEL/BMVEL1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal María Moliner</option>
                                                <option value=""BPCM/RBMVIP"">&nbsp;&nbsp;&gt;VILLA DEL PRADO. Biblioteca Municipal de Villa del Prado</option>
                                                <option value=""BPCM/RBMVIP/BMVIP1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Alfonso Ussía de Villa del Prado</option>
                                                <option value=""BPCM/RBMVIB"">&nbsp;&nbsp;&gt;VILLALBILLA. Bibliotecas Municipales de Villalbilla</option>
                                                <option value=""BPCM/RBMVIB/BMVIB1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal El Sauce</option>
                                                <option value=""BPCM/RBMVIB/BMVIB2"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Centro de Lectura</option>
                                                <option value=""BPCM/RBMVNV"">&nbsp;&nbsp;&gt;VILLANUEVA DE LA CAÑADA. Biblioteca Municipal de Villanueva de la Cañada</option>
                                                <option value=""BPCM/RBMVNV/BMVNV1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;VILLANUEVA DE LA CAÑADA. Biblioteca Municipal Fernando Lázaro Carreter</option>
                                                <option value=""BPCM/RBMVIL"">&nbsp;&nbsp;&gt;VILLANUEVA DEL PARDILLO. Biblioteca Municipal de Villanueva del Pardillo</option>
                                                <option value=""BPCM/RBMVIL/BMVIL1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal de Villanueva del Pardillo</option>
                                                <option value=""BPCM/RBMVVO"">&nbsp;&nbsp;&gt;VILLAVICIOSA DE ODÓN. Biblioteca Municipal de Villaviciosa de Odón</option>
                                                <option value=""BPCM/RBMVVO/BMVVO1"">&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;Biblioteca Municipal Luis de Góngora</option>
                                            </select>
                                        </span>
                                        <script type=""text/javascript"">/*
                                            <![CDATA[*/
function addes(){
formatFields(0);
document.abndocu.target = ""_self"";
document.abndocu.ACC.value = ""223"";
document.abndocu.submit();
}ujson.ej = {n:""3""}
/*Despliega los ejemplares si se ha seleccionado una sucursal*/
var selectSubcat = A$(""subcat"");
if(selectSubcat)
{
if(selectSubcat.selectedIndex)
{
var table = document.getElementsByTagName('table');
var span = document.getElementsByTagName('span');
var spanLength = span.length;
for (var i = 0; i < table.length; i++){
if (table[i].className=='dtNone')
{
table[i].className='dtBlock';
}
}
for(var i=0; i<spanLength; i++)
{
if (span[i].className=='linkDespliega')
{
span[i].style.display=""none"";
}
}
}
}
/*]]>*/
                                        </script>
                                    </div>
                                    <div id=""divL4"" class=""divDoc divTabs"">
                                        <!--[ if lt IE 7 ]>
                                        <style type=""text/css"">.com {position: absolute;}</style>
                                        <![ endif ]-->
                                        <!--[ if IE 7 ]>
                                        <style type=""text/css"">.cit {display:inline-block;}</style>
                                        <![ endif ]-->
                                        <script type=""text/javascript"">/*
                                            <![CDATA[*/
ujson.cm = {cn:1, n:""0""}
function shareTwitter(frm){
if(frm.xtweet.checked){
var url = 'https://twitter.com/share?url='+ujson.like+'&text='+encodeURIComponent(frm.xsctit.value+'\n'+frm.xsccom.value)+'&';
window.open(url,'share','height=450,width=550,toolbar=0,location=0,menubar=0,directories=0,scrollbars=0');
}
}
/*]]>*/
                                        </script>
                                        <br/>
                                        <div id=""loadCom"" class=""detmain detcom"">
                                            <div class=""ctit"">Opiniones de los lectores sobre este título</div>
                                            <div class=""cbar"">
                                                <div>
                                                    <script type=""text/javascript"">
//Comentarios para lectores identificados
var logLector=0;
</script>
                                                    <script type=""text/javascript"">
if(!logLector){
writeTag('
                                                        <img src=""/biblio_publicas/imag/cnota.gif"" title=""Comparte con los demás lectores tu experiencia con este libro"" alt=""Comparte con los demás lectores tu experiencia con este libro""/>&nbsp;Identifícate para opinar');
}
                                                    </script>
                                                </div>
                                                <strong>0 opiniones enviadas (Nota media 0/5)</strong>
                                            </div>
                                            <br/>
                                            <div id=""viewPart"">

</div>
                                        </div>
                                        <br/>
                                        <div id=""addCom"">
                                            <div class=""ctt"" onmousedown=""clickDV(event,this);"" onmouseup=""dropDV();"">
                                                <div class=""cit move"">
                                                    <div class=""cct"">Añadir Comentario sobre este título</div>
                                                    <div class=""crt"">
                                                        <img src=""/biblio_publicas/imag/close.gif"" onclick=""move.dv=null;chide(0);"" alt=""Cerrar""/>
                                                    </div>
                                                    <div class=""empty""></div>
                                                </div>
                                            </div>
                                            <div class=""ccom add"">
                                                <br/>
                                                <form action=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8"" method=""post"" name=""abcform"" onsubmit=""return addcm(this);"">
                                                    <input type=""hidden"" name=""ACC"" value=""167""/>
                                                    <div id=""cadd"">
                                                        <div class=""breakp"">Los campos con asterisco(*) son obligatorios</div>
                                                        <br/>
                                                        <div id=""bubble"" class=""bubble"">
                                                            <a href=""#"" onclick=""this.parentNode.className='bubble';return false;"" class=""bb"">
                                                                <span class=""tt"">
                                                                    <span class=""tp""></span>
                                                                    <span class=""md"">Debe completar los campos obligatorios</span>
                                                                    <span class=""bt""></span>
                                                                </span>
                                                            </a>
                                                        </div>
                                                        <div>
                                                            <label for=""xsctit"">* Asunto:</label>
                                                            <span class=""spcadd"">
                                                                <input type=""text"" name=""xsctit"" id=""xsctit"" class=""ctxt"" maxlength=""60""/>
                                                            </span>
                                                        </div>
                                                        <div>
                                                            <label for=""xsccom"">Comentario:</label>
                                                            <span class=""spcadd"">
                                                                <textarea name=""xsccom"" id=""xsccom"" class=""ctxt"" rows=""8"" cols=""cols""></textarea>
                                                            </span>
                                                        </div>
                                                        <div>
                                                            <label for=""xscval"">* Valoración:</label>
                                                            <span class=""spcadd"">
                                                                <select name=""xscval"" id=""xscval"">
                                                                    <option selected=""selected"" value=""""></option>
                                                                    <option value=""1"">1 (mínimo)</option>
                                                                    <option value=""2"">2</option>
                                                                    <option value=""3"">3</option>
                                                                    <option value=""4"">4</option>
                                                                    <option value=""5"">5 (máximo)</option>
                                                                </select>
                                                            </span>
                                                            <span class=""spshare"">
                                                                <script type=""text/javascript"">/*
                                                                    <![CDATA[*/writeTag('<input type=""checkbox"" name=""xtweet"" id=""xtweet""/><label for=""xtweet"">Tuitear</label>')/*]]>*/
                                                                </script>
                                                            </span>
                                                        </div>
                                                    </div>
                                                    <div class=""empty""></div>
                                                    <div class=""breakp cbutt"">
                                                        <script type=""text/javascript"">/*
                                                            <![CDATA[*/writeTag('<a href=""#"" onclick=""var frm=findForm(this);if(addcm(frm)){frm.submit();shareTwitter(frm);};return false"" class=""butt_send"">Aceptar</a>')/*]]>*/
                                                        </script>
                                                        <noscript>
                                                            <input type=""submit"" class=""butt_send addreg"" value=""Aceptar""/>
                                                        </noscript>
                                                        <a href=""#"" class=""butt_send addreg showhidebutt"" onclick=""chide(0);return false;"">Cancelar</a>
                                                    </div>
                                                    <p style=""    margin: 16px 2%; font-size: 0.8em; color: #850224; text-align: center; font-weight: 500;"">La Comunidad de Madrid se reserva la posibilidad de proceder en cualquier momento a modificar o eliminar aquellos comentarios que a su criterio considere inadecuados.</p>
                                                </form>
                                                <br/>
                                            </div>
                                        </div>
                                        <div id=""viewCom"">

</div>
                                    </div>
                                    <div id=""divL5"" class=""divDoc divTabs"">
                                        <br/>
                                        <div id=""editTag"">
                                            <div class=""ctt"" onmousedown=""clickDV(event,this);"" onmouseup=""dropDV();"">
                                                <div class=""cit move"">
                                                    <div class=""cct"">Etiquetas: filtrar por término</div>
                                                    <div class=""crt"">
                                                        <img src=""/biblio_publicas/imag/close.gif"" onclick=""chide(0);"" alt=""Cerrar""/>
                                                    </div>
                                                    <div class=""empty""></div>
                                                </div>
                                            </div>
                                            <div class=""ccom add"">
                                                <br/>
                                                <br/>
                                                <div class=""tagadd"">
                                                    <form action=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8"" method=""post"" onsubmit=""return edittag(this);"">
                                                        <input type=""hidden"" name=""ACC"" value=""313""/>
                                                        <input type=""hidden"" name=""DOC"" value=""2""/>
                                                        <div class=""findTerm"">
                                                            <label for=""xsterm"">Buscar:</label>
                                                            <div>
                                                                <input type=""text"" name=""xsterm"" id=""xsterm"" class=""inpTagEdit"" maxlength=""255""/>
                                                                <div id=""bubble7"" class=""bubble"">
                                                                    <a href=""#"" onclick=""this.parentNode.className='bubble';return false;"" class=""bb"">
                                                                        <span class=""tt"">
                                                                            <span class=""tp""></span>
                                                                            <span class=""md"">Campo obligatorio</span>
                                                                            <span class=""bt""></span>
                                                                        </span>
                                                                    </a>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class=""empty""></div>
                                                        <br/>
                                                        <br/>
                                                        <div class=""breakp cbutt tbutt"">
                                                            <script type=""text/javascript"">
                                                                <!--
writeTag('<a href=""#"" onclick=""var frm=findForm(this);if(edittag(frm))frm.submit();return false"" class=""butt_send"">Aceptar</a>');
-->
                                                            </script>
                                                            <noscript>
                                                                <input type=""submit"" class=""butt_send"" value=""Aceptar""/>
                                                            </noscript>
                                                            <a href=""#"" class=""butt_send showhidebutt"" onclick=""chide(0);return false;"">Cancelar</a>
                                                        </div>
                                                        <br/>
                                                    </form>
                                                </div>
                                            </div>
                                        </div>
                                        <div id=""loadTag"" class=""detmain dettag"">
                                            <div class=""ctit"">Nube de etiquetas</div>
                                            <div class=""cbar"">
                                                <div>


</div>
                                                <strong>0 etiquetas </strong>
                                            </div>
                                            <div class=""tagresult""></div>
                                            <div id=""dtag"">

</div>
                                            <br/>
                                        </div>
                                        <br/>
                                        <script type=""text/javascript"">
                                            <!--
ujson.et = {si:""Etiqueta nueva"", no:""La etiqueta ya existe"", ot:""Etiqueta de otro título"", ip:""Etiqueta inapropiada"", acc:""314"", n:""0"", type:-1}
-->
                                        </script>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""regdoc"">
                            <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=165&amp;DOC=1&amp;LISTDSI=0"" onclick=""AbnOpacDoc(1);return false;"" title=""Anterior"" class=""noacti"">&#171;</a>
                            <a href='/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda?ACC=165&amp;DOC=1' class='noacti' title=""Registro 1"" onclick='AbnOpacDoc(""1"");return false;'>1</a>
                            <span class='barr'>&nbsp;|&nbsp;</span>
                            <span class='acti'>2</span>
                            <span class='barr'>&nbsp;|&nbsp;</span>
                            <a href='/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda?ACC=165&amp;DOC=3' class='noacti' title=""Registro 3"" onclick='AbnOpacDoc(""3"");return false;'>3</a>
                            <span class='barr'>&nbsp;|&nbsp;</span>
                            <a href='/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda?ACC=165&amp;DOC=4' class='noacti' title=""Registro 4"" onclick='AbnOpacDoc(""4"");return false;'>4</a>
                            <span class='barr'>&nbsp;|&nbsp;</span>
                            <a href='/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda?ACC=165&amp;DOC=5' class='noacti' title=""Registro 5"" onclick='AbnOpacDoc(""5"");return false;'>5</a>
                            <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=165&amp;DOC=3&amp;LISTDSI=0"" onclick=""AbnOpacDoc(3);return false;"" title=""Siguiente"" class=""noacti"">&#187;</a>
                        </div>
                        <br/>
                        <div class=""reglist"">
                            <div class=""reglistl"">
                                <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda?ACC=161&amp;DOC=2""  onclick=""AbnOpacListDoc('2');return false;"" class=""butt_send"">
                                    <i class=""fa list"" aria-hidden=""true"">&#xf03a;</i>Resultados
                                </a>
                                <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=120"" class=""butt_send"">
                                    <i class=""fa search"" aria-hidden=""true"">&#xf002;</i>Volver a Buscar
                                </a>
                            </div>
                            <div class=""reglistr"">
                                <h3 class=""recordsetlist"">Registro 
                                    <strong>2</strong> de
                                    <strong>875</strong>
                                </h3>
                                <form action=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8"" method=""post"">
                                    <input type=""hidden"" name=""ACC"" value=""165""/>
                                    <input type=""hidden"" name=""DOC"" value=""2""/>
                                    <input type=""hidden"" name=""xsrmax"" value=""875""/>
|
                                    <input type=""text"" id=""inregb"" name=""inregb"" class=""inpreg"" value=""2"" title=""""/>
                                    <script type=""text/javascript"">/*
                                        <![CDATA[*/writeTag('<a href=""#"" id=""n1"" onclick=""AbnOpacDoc(A$(\'inregb\').value);return false;"" class=""butt_send""  title=""""><i class=""fa fa-check"" aria-hidden=""true""></i></a>')/*]]>*/
                                    </script>
                                    <noscript>
                                        <input type=""submit"" name=""xsregb"" class=""butt_send"" value=""Registro""/>
                                    </noscript>
                                </form>
                            </div>
                            <div class=""empty""></div>
                        </div>
                        <br/>
                    </div>
                </div>
                <script type=""text/javascript"">
/*
                    <![CDATA[*/
function AbnChgHist() {
document.abnhist.submit();
}
function AbnChgFormat() {
document.abnfmat.submit();
}
function AbnOpacDoc(n) {
var ndoc = parseInt(n,10);
if (ndoc<1 || ndoc>ujson.cc.mx || isNaN(ndoc)) return;
document.abnform.DOC.value=ndoc;
document.abnform.ACC.value=165;
document.abnform.submit();
}
function AbnOpacListDoc(n) {
var ndoc = parseInt(n,10);
if (ndoc<1 || ndoc>ujson.cc.mx) return;
var acc = Number(ujson.cc.dsi)?163:161;
document.abnform.DOC.value=ndoc;
document.abnform.ACC.value=acc;
document.abnform.submit();
}
function AbnOpacCheckDoc(obj){
var param = ""&ACC=261&httprequest=1""; responsePost(""./"", param); putCheck(obj);
}
if(document.addEventListener) {
document.addEventListener(""DOMContentLoaded"", loadDocs, false);
} else {
window.onload = loadDocs;
}
vistaPrevia(1)
/*]]>*/

                </script>
            </div>
            <div class=""section"">
                <div class=""newfacedoc"">
                    <ul id=""tablist"" class=""[xsface]"">
                        <li class=""tabsel"">
                            <a href=""#tagface"" onclick=""activateTab(this.parentNode,'tabface','tabdesc');return false;"">
                                <i class=""fa info-circle"" aria-hidden=""true"">&#xf05a;</i>
                                <span>Información relacionada</span>
                            </a>
                        </li>
                        <li>
                            <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=131&amp;CLV=1&amp;httprequest=1&amp;xsface=on&amp;DEST=T"" onclick=""AbnOpacAuto(this);return false;"">
                                <i class=""fa search"" aria-hidden=""true"">&#xf00e;</i>
                                <span>Descubrir</span>
                            </a>
                        </li>
                    </ul>
                    <div id=""tabcontent"">
                        <div id=""tabface"">
                            <a name=""tagface""></a>
                            <div class=""contentTag"">
                                <div class=""nborder"">
                                    <span class=""anchor"">
                                        <a name=""tools_lnk""></a>
                                    </span>
                                    <div class=""tools"">
                                        <h2 class=""nd"">Información sobre la autoridad</h2>
                                        <strong class=""titsection"">Más información sobre:</strong>
                                        <br/>
                                        <ul class=""docauth"">
                                            <li>
                                                <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda?ACC=140&amp;DOC=2&amp;AUT=578574&amp;AUTNOM=Scaraffia, Giuseppe (1950-)"">Scaraffia, Giuseppe (1950-)</a>
                                            </li>
                                            <li>
                                                <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda?ACC=140&amp;DOC=2&amp;AUT=585760&amp;AUTNOM=""></a>
                                            </li>
                                        </ul>
                                    </form>
                                </div>
                                <div class=""tools"">
                                    <h2 class=""nd"">Enlaces</h2>
                                    <form action=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8"" method=""post"" id=""ablkdocs"" name=""ablkdocs"">
                                        <input type=""hidden"" name=""ACC"" value=""181""/>
                                        <input type=""hidden"" name=""EXP"" value=""""/>
                                        <div class=""titsection"">
                                            <strong>Enlaces del registro:</strong>
                                        </div>
                                        <div class=""docslinks"">
                                            <br/>Otras obras de:
                                            <ul>
                                                <li>
                                                    <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=181&amp;EXP=(Scaraffia Giuseppe)[T100]"" onclick=""AbnLinkBdoc(this);return false;"">Scaraffia, Giuseppe (</a>
                                                </li>
                                            </ul>
                                            <br/>Otras ediciones de:
                                            <ul>
                                                <li>
                                                    <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=181&amp;EXP=(La novela de la Costa Azul)[T245]"" onclick=""AbnLinkBdoc(this);return false;"">La novela de la Costa Azul / </a>
                                                </li>
                                            </ul>
                                        </div>
                                    </form>
                                    <script type=""text/javascript"">
/*
                                        <![CDATA[*/
function AbnLinkBdoc(slink) {
var ret = linkDocs(slink);
if(ret){
document.ablkdocs.EXP.value=ret;
document.ablkdocs.submit();
}
}
/*]]>*/

                                    </script>
                                </div>
                                <div class=""tools"">
                                    <h2 class=""nd"">Enlaces</h2>
                                    <div class=""titsection"">
                                        <strong>Enlaces en la red:</strong>
                                    </div>
                                    <br/>
-
                                    <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=187"" target=""_blank"" onclick=""openw(this,620,500);return false;"">
                                        <strong>Generador de enlaces&nbsp;
                                            <span class=""logo"">absys
                                                <span class=""net"">NET</span>
                                            </span>c+I/link
                                        </strong>
                                    </a>
                                    <br/>
                                    <br/>
                                    <span id=""ilink""></span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id=""tabdesc"" class=""dvNone"">
                        <a name=""tagdesc""></a>
                        <div class=""contentTag"">
                            <div class=""facetit nborder"">
                                <br/>
                                <div id=""xxtiau""></div>
                                <ul id=""xxauto"">
                                    <li>
                                        <a href=""#""></a>
                                    </li>
                                </ul>
                                <br/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""empty""></div>
</div>
<div class=""copyright"">
    <a name=""contact_lnk"" class=""copy""></a>
    <ul class=""lnkLogo"">
        <li>
            <img src=""/biblio_publicas/imag/media/logopie.png"" />
        </li>
        <li>&#169; BPCM 2013-2016</li>
    </ul>
    <ul class=""lnkweb"">
        <li>
            <a href=""http://www.madrid.org/cs/Satellite?c=Page&cid=1109265698478&language=es&pagename=ComunidadMadrid%2FEstructura&pid=1109265698438&sc=2"" target=""_blank"">Sugerencias y quejas</a>
        </li>
    </ul>
    <ul class=""lnkweb"">
        <li>
            <a href=""http://www.madrid.org/cs/Satellite?pagename=ComunidadMadrid/Comunes/Presentacion/popUp&language=es&c=CM_Texto_FA&cid=1142636148876"" target=""_blank"">Aviso legal</a>
        </li>
        <li>
            <a href=""mailto:redbibliotecasmadrid@madrid.org"">Contacto</a>
        </li>
        <li>
            <a href=""http://www.madrid.org/cs/Satellite?pagename=ComunidadMadrid/Comunes/Presentacion/popUp&language=es&c=CM_Texto_FA&cid=1109266097450"" target=""_blank"" accesskey=""5"">Accesibilidad</a>
        </li>
        <li>
            <a href=""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT1?ACC=142"" accesskey=""4"">Mapa Web</a>
        </li>
    </ul>
    <div class=""empty""></div>
</div>
<div id=""upPage"">
    <a href=""#"" id=""upPageA"" onclick=""scrollToTop(500); return false"">
        <i class=""fa fa-arrow-circle-up"" aria-hidden=""true""></i>
    </a>
</div>
<script type=""text/javascript"">
function upPageScroll(event)
{
var top = this.scrollY;
var up = A$(""upPage"");
if(up){
if(top>200){
up.style.display=""block"";
}
else{
up.style.display=""none"";
}
}
}
if(window.attachEvent)
{
window.attachEvent(""onscroll"", upPageScroll);
}
else if(window.addEventListener)
{
window.addEventListener(""scroll"", upPageScroll, false);
}
function scrollToTop(scrollDuration) {
var scrollStep = -window.scrollY / (scrollDuration / 15),
scrollInterval = setInterval(function(){
if ( window.scrollY != 0 ) {
window.scrollBy( 0, scrollStep );
}
else clearInterval(scrollInterval); 
},15);
}
</script>
<script type=""text/javascript"">/*
    <![CDATA[*/
ilink(""/biblio_publicas/cgi-bin/abnetopac/O9506/ID4a06ebda/NT8?ACC=188"");
function AbnOpacAuto(t){
try{
var dc = A$('xxauto'), dv, li = dc.getElementsByTagName('li')[0], href = li.getElementsByTagName('a')[0];
if(dc && li && href && !href.innerHTML.length){
Loading();
setTimeout(function(){
var param = t.href,
ret = response(param);
if(ret){
var regExp = new RegExp('<ul id=""xxauto"">(.|\n)+?</ul>',""gi""), regExp1 = new RegExp('<div id=""xxtiau"">(.*?)</div>',""gi""),
arMatch = regExp.exec(ret), arMatch1 = regExp1.exec(ret);
if(arMatch){
dc.innerHTML = arMatch[0];
A$('xxtiau').style.display = ""none"";
}if(arMatch1){
dv = document.createElement(""div"");
dv.appendChild(document.createTextNode(arMatch1[1]));
dc.parentNode.insertBefore(dv,dc);
}LoadingHide();
selTab(t);
};
},0);
}else{
selTab(t);
}
}catch(e){LoadingHide()}
}
function selTab(t){
activateTab(t.parentNode,'tabdesc','tabface');
}
/*]]>*/
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
