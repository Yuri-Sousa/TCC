using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class buscarhtmlrecuperarsenha : GXProcedure
   {
      public buscarhtmlrecuperarsenha( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public buscarhtmlrecuperarsenha( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( GeneXus.Programs.genexussecurity.SdtGAMUser aP0_User ,
                           string aP1_KeyToChangePassword ,
                           out string aP2_HTML )
      {
         this.AV8User = aP0_User;
         this.AV9KeyToChangePassword = aP1_KeyToChangePassword;
         this.AV10HTML = "" ;
         initialize();
         executePrivate();
         aP2_HTML=this.AV10HTML;
      }

      public string executeUdp( GeneXus.Programs.genexussecurity.SdtGAMUser aP0_User ,
                                string aP1_KeyToChangePassword )
      {
         execute(aP0_User, aP1_KeyToChangePassword, out aP2_HTML);
         return AV10HTML ;
      }

      public void executeSubmit( GeneXus.Programs.genexussecurity.SdtGAMUser aP0_User ,
                                 string aP1_KeyToChangePassword ,
                                 out string aP2_HTML )
      {
         buscarhtmlrecuperarsenha objbuscarhtmlrecuperarsenha;
         objbuscarhtmlrecuperarsenha = new buscarhtmlrecuperarsenha();
         objbuscarhtmlrecuperarsenha.AV8User = aP0_User;
         objbuscarhtmlrecuperarsenha.AV9KeyToChangePassword = aP1_KeyToChangePassword;
         objbuscarhtmlrecuperarsenha.AV10HTML = "" ;
         objbuscarhtmlrecuperarsenha.context.SetSubmitInitialConfig(context);
         objbuscarhtmlrecuperarsenha.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objbuscarhtmlrecuperarsenha);
         aP2_HTML=this.AV10HTML;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((buscarhtmlrecuperarsenha)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw e ;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10HTML = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">";
         AV10HTML += "<html xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" style=\"width:100%;font-family:helvetica, " + "'helvetica neue'" + ", arial, verdana, sans-serif;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;padding:0;Margin:0\">";
         AV10HTML += "<head>";
         AV10HTML += "<meta charset=\"UTF-8\">";
         AV10HTML += "<meta content=\"width=device-width, initial-scale=1\" name=\"viewport\">";
         AV10HTML += "<meta name=\"x-apple-disable-message-reformatting\">";
         AV10HTML += "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">";
         AV10HTML += "<meta content=\"telephone=no\" name=\"format-detection\">";
         AV10HTML += "<title>Recuperar Senha</title>";
         AV10HTML += "<style type=\"text/css\">";
         AV10HTML += "#outlook a {";
         AV10HTML += "padding:0;";
         AV10HTML += "}";
         AV10HTML += ".ExternalClass {";
         AV10HTML += "width:100%;";
         AV10HTML += "}";
         AV10HTML += ".ExternalClass,";
         AV10HTML += ".ExternalClass p,";
         AV10HTML += ".ExternalClass span,";
         AV10HTML += ".ExternalClass font,";
         AV10HTML += ".ExternalClass td,";
         AV10HTML += ".ExternalClass div {";
         AV10HTML += "line-height:100%;";
         AV10HTML += "}";
         AV10HTML += ".es-button {";
         AV10HTML += "	mso-style-priority:100!important;";
         AV10HTML += "	text-decoration:none!important;";
         AV10HTML += "}";
         AV10HTML += "a[x-apple-data-detectors] {";
         AV10HTML += "	color:inherit!important;";
         AV10HTML += "	text-decoration:none!important;";
         AV10HTML += "	font-size:inherit!important;";
         AV10HTML += "	font-family:inherit!important;";
         AV10HTML += "	font-weight:inherit!important;";
         AV10HTML += "	line-height:inherit!important;";
         AV10HTML += "}";
         AV10HTML += ".es-desk-hidden {";
         AV10HTML += "	display:none;";
         AV10HTML += "	float:left;";
         AV10HTML += "	overflow:hidden;";
         AV10HTML += "	width:0;";
         AV10HTML += "	max-height:0;";
         AV10HTML += "	line-height:0;";
         AV10HTML += "	mso-hide:all;";
         AV10HTML += "}";
         AV10HTML += ".es-button-border:hover a.es-button, .es-button-border:hover button.es-button {";
         AV10HTML += "	background:#ffffff!important;";
         AV10HTML += "	border-color:#ffffff!important;";
         AV10HTML += "}";
         AV10HTML += ".es-button-border:hover {";
         AV10HTML += "	background:#ffffff!important;";
         AV10HTML += "	border-style:solid solid solid solid!important;";
         AV10HTML += "	border-color:#3d5ca3 #3d5ca3 #3d5ca3 #3d5ca3!important;";
         AV10HTML += "}";
         AV10HTML += "[data-ogsb] .es-button {";
         AV10HTML += "	border-width:0!important;";
         AV10HTML += "	padding:15px 20px 15px 20px!important;";
         AV10HTML += "}";
         AV10HTML += "td .es-button-border:hover a.es-button-1 {";
         AV10HTML += "	background:#11f2cd!important;";
         AV10HTML += "	border-color:#11f2cd!important;";
         AV10HTML += "}";
         AV10HTML += "td .es-button-border-2:hover {";
         AV10HTML += "	background:#11f2cd!important;";
         AV10HTML += "}";
         AV10HTML += "@media only screen and (max-width:600px) {p, ul li, ol li, a { line-height:150%!important } h1 { font-size:20px!important; text-align:center; line-height:120%!important } h2 { font-size:16px!important; text-align:left; line-height:120%!important } h3 { font-size:20px!important; text-align:center; line-height:120%!important } .es-header-body h1 a, .es-content-body h1 a, .es-footer-body h1 a { font-size:20px!important } h2 a { text-align:left } .es-header-body h2 a, .es-content-body h2 a, .es-footer-body h2 a { font-size:16px!important } .es-header-body h3 a, .es-content-body h3 a, .es-footer-body h3 a { font-size:20px!important } .es-menu td a { font-size:14px!important } .es-header-body p, .es-header-body ul li, .es-header-body ol li, .es-header-body a { font-size:10px!important } .es-content-body p, .es-content-body ul li, .es-content-body ol li, .es-content-body a { font-size:16px!important } .es-footer-body p, .es-footer-body ul li, .es-footer-body ol li, .es-footer-body a { font-size:12px!important } .es-infoblock p, .es-infoblock ul li, .es-infoblock ol li, .es-infoblock a { font-size:12px!important } *[class=\"gmail-fix\"] { display:none!important } .es-m-txt-c, .es-m-txt-c h1, .es-m-txt-c h2, .es-m-txt-c h3 { text-align:center!important } .es-m-txt-r, .es-m-txt-r h1, .es-m-txt-r h2, .es-m-txt-r h3 { text-align:right!important } .es-m-txt-l, .es-m-txt-l h1, .es-m-txt-l h2, .es-m-txt-l h3 { text-align:left!important } .es-m-txt-r img, .es-m-txt-c img, .es-m-txt-l img { display:inline!important } .es-button-border { display:block!important } a.es-button, button.es-button { font-size:14px!important; display:block!important; border-left-width:0px!important; border-right-width:0px!important } .es-btn-fw { border-width:10px 0px!important; text-align:center!important } .es-adaptive table, .es-btn-fw, .es-btn-fw-brdr, .es-left, .es-right { width:100%!important } .es-content table, .es-header table, .es-footer table, .es-content, .es-footer, .es-header { width:100%!important; max-width:600px!important } .es-adapt-td { display:block!important; width:100%!important } .adapt-img { width:100%!important; height:auto!important } .es-m-p0 { padding:0px!important } .es-m-p0r { padding-right:0px!important } .es-m-p0l { padding-left:0px!important } .es-m-p0t { padding-top:0px!important } .es-m-p0b { padding-bottom:0!important } .es-m-p20b { padding-bottom:20px!important } .es-mobile-hidden, .es-hidden { display:none!important } tr.es-desk-hidden, td.es-desk-hidden, table.es-desk-hidden { width:auto!important; overflow:visible!important; float:none!important; max-height:inherit!important; line-height:inherit!important } tr.es-desk-hidden { display:table-row!important } table.es-desk-hidden { display:table!important } td.es-desk-menu-hidden { display:table-cell!important } .es-menu td { width:1%!important } table.es-table-not-adapt, .esd-block-html table { width:auto!important } table.es-social { display:inline-block!important } table.es-social td { display:inline-block!important } }";
         AV10HTML += "</style>";
         AV10HTML += " </head>";
         AV10HTML += " <body style=\"width:100%;font-family:helvetica, " + "'helvetica neue'" + ", arial, verdana, sans-serif;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;padding:0;Margin:0\">";
         AV10HTML += "  <div class=\"es-wrapper-color\" style=\"background-color:#FAFAFA\">";
         AV10HTML += "   <table class=\"es-wrapper\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;padding:0;Margin:0;width:100%;height:100%;background-repeat:repeat;background-position:center top\">";
         AV10HTML += "     <tr style=\"border-collapse:collapse\">";
         AV10HTML += "      <td valign=\"top\" style=\"padding:0;Margin:0\"> ";
         AV10HTML += "       <table cellpadding=\"0\" cellspacing=\"0\" class=\"es-header\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%;background-color:transparent;background-repeat:repeat;background-position:center top\">";
         AV10HTML += "         <tr style=\"border-collapse:collapse\">";
         AV10HTML += "          <td class=\"es-adaptive\" align=\"center\" style=\"padding:0;Margin:0\"> ";
         AV10HTML += "           <table class=\"es-header-body\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#3D5CA3;width:700px;box-shadow: rgb(0 0 0 / 15%) 0 0 1.6px;margin-top: 20px;border-bottom: 1px solid #edebe9;\" cellspacing=\"0\" cellpadding=\"0\" bgcolor=\"#3d5ca3\" align=\"center\"> ";
         AV10HTML += "             <tr class=\"es-visible-simple-html-only\" style=\"border-collapse:collapse\"> ";
         AV10HTML += "              <td class=\"es-struct-html\" align=\"left\" bgcolor=\"#ffffff\" style=\"padding:20px;Margin:0;background-color:#FFFFFF\"> ";
         AV10HTML += "               <table cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"> ";
         AV10HTML += "                 <tr style=\"border-collapse:collapse\"> ";
         AV10HTML += "                  <td align=\"left\" style=\"padding:0;Margin:0;width:560px\"> ";
         AV10HTML += "                   <table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"> ";
         AV10HTML += "                     <tr style=\"border-collapse:collapse\"> ";
         AV10HTML += "                      <td class=\"es-m-p0l es-m-txt-c\" align=\"left\" style=\"padding:0;Margin:0;font-size:0px\"><a href=\"https://viewstripo.email\" target=\"_blank\" style=\"-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;text-decoration:none;color:#1376C8;font-size:14px\"><img src=\"https://rirwxk.stripocdn.email/content/guids/6c81c9d2-53c7-4b93-9055-680f4705bb87/images/87921619709242632.png\" alt style=\"display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic\" width=\"183\"></a></td> ";
         AV10HTML += "                     </tr> ";
         AV10HTML += "                   </table></td> ";
         AV10HTML += "                 </tr> ";
         AV10HTML += "               </table></td> ";
         AV10HTML += "             </tr> ";
         AV10HTML += "           </table></td> ";
         AV10HTML += "         </tr> ";
         AV10HTML += "       </table> ";
         AV10HTML += "       <table class=\"es-content\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%\"> ";
         AV10HTML += "         <tr style=\"border-collapse:collapse\"> ";
         AV10HTML += "          <td style=\"padding:0;Margin:0;background-color:#FAFAFA\" bgcolor=\"#fafafa\" align=\"center\"> ";
         AV10HTML += "           <table class=\"es-content-body\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:700px;box-shadow: rgb(0 0 0 / 15%) 0 0 1.6px;\" cellspacing=\"0\" cellpadding=\"0\" bgcolor=\"#ffffff\" align=\"center\"> ";
         AV10HTML += "             <tr style=\"border-collapse:collapse\"> ";
         AV10HTML += "              <td style=\"padding:0;Margin:0;padding-left:20px;padding-right:20px;padding-top:40px;background-color:transparent;background-position:left top\" bgcolor=\"transparent\" align=\"left\"> ";
         AV10HTML += "               <table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"> ";
         AV10HTML += "                 <tr style=\"border-collapse:collapse\"> ";
         AV10HTML += "                  <td valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;width:560px\"> ";
         AV10HTML += "                   <table style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-position:left top\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" role=\"presentation\"> ";
         AV10HTML += "                     <tr style=\"border-collapse:collapse\"> ";
         AV10HTML += "                      <td align=\"center\" style=\"padding:0;Margin:0;padding-top:5px;padding-bottom:5px;font-size:0px\"><img src=\"https://rirwxk.stripocdn.email/content/guids/6c81c9d2-53c7-4b93-9055-680f4705bb87/images/83791619710211989.jpg\" alt style=\"display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic\" width=\"175\"></td> ";
         AV10HTML += "                     </tr> ";
         AV10HTML += "                     <tr style=\"border-collapse:collapse\"> ";
         AV10HTML += "                     <td align=\"center\" style=\"padding:0;Margin:0;padding-top:15px;padding-bottom:15px\"><h1 style=\"Margin:0;line-height:24px;mso-line-height-rule:exactly;font-family:arial, " + "'helvetica neue'" + ", helvetica, sans-serif;font-size:20px;font-style:normal;font-weight:normal;color:#333333\"><b>Esqueceu a sua senha?</b></h1></td> ";
         AV10HTML += "                     </tr> ";
         AV10HTML += "                     <tr style=\"border-collapse:collapse\"> ";
         AV10HTML += "                      <td align=\"center\" style=\"padding:0;Margin:0;padding-left:40px;padding-right:40px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:helvetica, " + "'helvetica neue'" + ", arial, verdana, sans-serif;line-height:24px;color:#666666;font-size:16px\">Olá,&nbsp;" + StringUtil.Trim( AV8User.gxTpr_Firstname) + " " + StringUtil.Trim( AV8User.gxTpr_Lastname) + "!</p></td> ";
         AV10HTML += "                     </tr> ";
         AV10HTML += "                     <tr style=\"border-collapse:collapse\"> ";
         AV10HTML += "                      <td align=\"center\" style=\"padding:0;Margin:0;padding-right:35px;padding-left:40px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:helvetica, " + "'helvetica neue'" + ", arial, verdana, sans-serif;line-height:24px;color:#666666;font-size:16px\">Para recuperar a sua senha, clique no botão abaixo:</p></td> ";
         AV10HTML += "                     </tr> ";
         AV10HTML += "                     <tr style=\"border-collapse:collapse\"> ";
         AV11Link = StringUtil.Trim( StringUtil.StringReplace( AV12HttpRequest.BaseURL, "/TCC", "")) + formatLink("gamrecoverpasswordstep2.aspx", new object[] {GXUtil.UrlEncode(StringUtil.RTrim(AV9KeyToChangePassword))}, new string[] {"KeyToChangePassword"}) ;
         AV10HTML += "                      <td align=\"center\" style=\"Margin:0;padding-left:10px;padding-right:10px;padding-top:40px;padding-bottom:40px\"><span class=\"es-button-border-2 es-button-border\" style=\"border-style:solid;border-color:#FFFFFF;background:#0AC6A6;border-width:2px;display:inline-block;border-radius:10px;width:auto\"><a href=\"" + StringUtil.Trim( AV11Link) + "\" class=\"es-button es-button-1\" target=\"_blank\" style=\"mso-style-priority:100 !important;text-decoration:none;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;color:#FFFFFF;font-size:14px;border-style:solid;border-color:#0AC6A6;border-width:15px 20px 15px 20px;display:inline-block;background:#0AC6A6;border-radius:10px;font-family:arial, " + "'helvetica neue'" + ", helvetica, sans-serif;font-weight:bold;font-style:normal;line-height:17px;width:auto;text-align:center\">Recuperar Senha</a></span></td>";
         AV10HTML += "                     </tr>";
         AV10HTML += "                     <tr style=\"border-collapse:collapse\">";
         AV10HTML += "                     <td align=\"center\" style=\"padding:0;Margin:0;padding-top:25px;padding-left:40px;padding-right:40px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:helvetica, " + "'helvetica neue'" + ", arial, verdana, sans-serif;line-height:24px;color:#666666;font-size:16px\">Caso não tenha sido você, ignore este e-mail.<br><br></p></td>";
         AV10HTML += "                     </tr> ";
         AV10HTML += "                   </table></td> ";
         AV10HTML += "                 </tr> ";
         AV10HTML += "               </table></td> ";
         AV10HTML += "             </tr> ";
         AV10HTML += "           </table></td> ";
         AV10HTML += "         </tr> ";
         AV10HTML += "       </table> ";
         AV10HTML += "       <table class=\"es-footer\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%;background-color:transparent;background-repeat:repeat;background-position:center top\"> ";
         AV10HTML += "         <tr style=\"border-collapse:collapse\"> ";
         AV10HTML += "          <td style=\"padding:0;Margin:0;background-color:#FAFAFA\" bgcolor=\"#fafafa\" align=\"center\"> ";
         AV10HTML += "           <table class=\"es-footer-body\" cellspacing=\"0\" cellpadding=\"0\" bgcolor=\"#ffffff\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:transparent;width:700px;box-shadow: " + "'rgb(0 0 0 / 15%) 0px 2px 1.6px'" + ";margin-bottom: 20px;\">";
         AV10HTML += "            <tr style=\"border-collapse:collapse\"> ";
         AV10HTML += "              <td style=\"Margin:0;padding-top:10px;padding-left:20px;padding-right:20px;padding-bottom:30px;background-color:#0AC6A6\" bgcolor=\"#0ac6a6\" align=\"left\"> ";
         AV10HTML += "               <table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"> ";
         AV10HTML += "                 <tr style=\"border-collapse:collapse\"> ";
         AV10HTML += "                  <td valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;width:560px\"> ";
         AV10HTML += "                   <table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">";
         AV10HTML += "                     <tr style=\"border-collapse:collapse\">";
         AV10HTML += "                      <td align=\"left\" style=\"padding:0;Margin:0;padding-top:5px;padding-bottom:5px\"><h2 style=\"Margin:0;line-height:19px;mso-line-height-rule:exactly;font-family:arial, " + "'helvetica neue'" + ", helvetica, sans-serif;font-size:16px;font-style:normal;font-weight:normal;color:#FFFFFF\"><strong>Alguma dúvida?</strong></h2></td>";
         AV10HTML += "                     </tr>";
         AV10HTML += "                     <tr style=\"border-collapse:collapse\">";
         AV10HTML += "                      <td align=\"left\" style=\"padding:0;Margin:0;padding-bottom:5px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:helvetica, " + "'helvetica neue'" + ", arial, verdana, sans-serif;line-height:21px;color:#FFFFFF;font-size:14px\">Entre em contato conosco pelo: y.track.tcc@gmail.com</p></td>";
         AV10HTML += "                     </tr>";
         AV10HTML += "                  </table></td>";
         AV10HTML += "                 </tr>";
         AV10HTML += "               </table></td>";
         AV10HTML += "             </tr>";
         AV10HTML += "           </table></td>";
         AV10HTML += "         </tr>";
         AV10HTML += "       </table></td>";
         AV10HTML += "     </tr>";
         AV10HTML += "   </table>";
         AV10HTML += "  </div>";
         AV10HTML += " </body>";
         AV10HTML += "</html>";
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         exitApplication();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV10HTML = "";
         AV11Link = "";
         AV12HttpRequest = new GxHttpRequest( context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV9KeyToChangePassword ;
      private string AV10HTML ;
      private string AV11Link ;
      private string aP2_HTML ;
      private GxHttpRequest AV12HttpRequest ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV8User ;
   }

}
