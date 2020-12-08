<%@ Page Title="" Language="C#" MasterPageFile="~/View/Shared/Main.Master" AutoEventWireup="true" Async="true" CodeBehind="contacto.aspx.cs" Inherits="Donatech.View.contacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
<style>
    img{ max-width:100%;}

    .inbox_people {
      background: #f8f8f8 none repeat scroll 0 0;
      float: left;
      overflow: hidden;
      width: 40%; border-right:1px solid #c4c4c4;
    }
    .inbox_msg {
      border: 1px solid #c4c4c4;
      clear: both;
      overflow: hidden;
    }
    .top_spac{ margin: 20px 0 0;}

    .recent_heading {float: left; width:40%;}
    .headind_srch{ padding:10px 29px 10px 20px; overflow:hidden; border-bottom:1px solid #c4c4c4;}

    .recent_heading h4 {
      color: #05728f;
      font-size: 21px;
      margin: auto;
    }
    .srch_bar input{ border:1px solid #cdcdcd; border-width:0 0 1px 0; width:80%; padding:2px 0 4px 6px; background:none;}
    .srch_bar .input-group-addon button {
      background: rgba(0, 0, 0, 0) none repeat scroll 0 0;
      border: medium none;
      padding: 0;
      color: #707070;
      font-size: 18px;
    }
    .srch_bar .input-group-addon { margin: 0 0 0 -27px;}

    .chat_ib h5{ font-size:15px; color:#464646; margin:0 0 8px 0;}
    .chat_ib h5 span{ font-size:13px; float:right;}
    .chat_ib p{ font-size:14px; color:#989898; margin:auto}
    .chat_img {
      float: left;
      width: 11%;
    }
    .chat_ib {
      float: left;
      padding: 0 0 0 15px;
      width: 88%;
    }

    .chat_people{ overflow:hidden; clear:both;}
    .chat_list {
      border-bottom: 1px solid #c4c4c4;
      margin: 0;
      padding: 18px 16px 10px;
    }
    .inbox_chat { height: 550px; overflow-y: scroll;}

    .active_chat{ background:#ebebeb;}

    .incoming_msg_img {
      display: inline-block;
      width: 6%;
    }
    .received_msg {
      display: inline-block;
      padding: 0 0 0 10px;
      vertical-align: top;
      width: 92%;
     }
     .received_withd_msg p {
      background: #ebebeb none repeat scroll 0 0;
      border-radius: 3px;
      color: #646464;
      font-size: 14px;
      margin: 0;
      padding: 5px 10px 5px 12px;
      width: 100%;
    }
    .time_date {
      color: #747474;
      display: block;
      font-size: 12px;
      margin: 8px 0 0;
    }
    .received_withd_msg { width: 57%;}
    .mesgs {
      float: left;
      padding: 30px 15px 0 25px;
      width: 100%;
    }

     .sent_msg p {
      background: #05728f none repeat scroll 0 0;
      border-radius: 3px;
      font-size: 14px;
      margin: 0; color:#fff;
      padding: 5px 10px 5px 12px;
      width:100%;
    }
    .outgoing_msg{ overflow:hidden; margin:26px 0 26px;}
    .sent_msg {
      float: right;
      width: 46%;
    }
    .input_msg_write input {
      background: rgba(0, 0, 0, 0) none repeat scroll 0 0;
      border: medium none;
      color: #4c4c4c;
      font-size: 15px;
      min-height: 48px;
      width: 100%;
    }

    .type_msg {border-top: 1px solid #c4c4c4;position: relative;}
    .msg_send_btn {
      background: #05728f none repeat scroll 0 0;
      border: medium none;
      border-radius: 50%;
      color: #fff;
      cursor: pointer;
      font-size: 17px;
      height: 33px;
      position: absolute;
      right: 0;
      top: 11px;
      width: 33px;
    }
    .messaging { padding: 0 0 50px 0;}
    .msg_history {
      height: 516px;
      overflow-y: auto;
    }
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <script>
        const volverAction = () => {
            history.back()
        }

        const enviarMensaje = () => {
            $('#<%=btnSendMessageInp.ClientID%>').click()
        }

        const initPage = () => {
            $(document).ready(() => {
                $('#btnVerMensajes').click()
            })
        }

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(initPage)
    </script>

    <div class="container">
        <div id="alertInfoMessage" class="alert alert-info" role="alert" style="display:none">
            &nbsp;
        </div>
        <div id="alertErrorMessage" class="alert alert-danger" role="alert" style="display:none">
            &nbsp;
        </div>

        <br />
        <div class="card mb-3">
            <div class="card-body">
                <h5 class="card-title">
                    Informaci&oacute;n de Contacto
                </h5>
                <p class="card-text">
                    <asp:Literal ID="ltlNombre" runat="server"></asp:Literal>
                </p>
                <hr />
                <p class="card-text">
                    <small class="text-muted">Email: <asp:Literal ID="ltlEmail" runat="server"></asp:Literal></small>
                </p>
                <p class="card-text">
                   <small class="text-muted">Celular: <asp:Literal ID="ltlCelular" runat="server"></asp:Literal></small>
                </p>
                <p class="card-text">
                   <small class="text-muted">Direcci&oacute;n: <asp:Literal ID="ltlDireccion" runat="server"></asp:Literal></small>
                </p>
            </div>
        </div>

        <p>
          <a class="btn btn-info" id="btnVerMensajes" data-toggle="collapse" href="#collapseExample" role="button" aria-expanded="false" aria-controls="collapseExample">
            Ver Mensajes
          </a>
        </p>
        <div class="collapse" id="collapseExample">
          <div class="card card-body">
            <div class="messaging">
                <div class="inbox_msg">
                    <div class="mesgs">
                      <div class="msg_history">
                          <asp:Repeater ID="lstMensajes" runat="server">
                              <ItemTemplate>
                                  <div class='<%# Eval("SesionEmisor").ToString() == "True" ? "outgoing_msg" : "incoming_msg"%>'>
                                      <div style='<%# Eval("SesionEmisor").ToString() == "True" ? "display:none" : "" %>' class="incoming_msg_img">
                                          <img src='<%=ResolveUrl("~/img/user-profile-03.png") %>' alt="user">
                                      </div>
                                      <div class='<%# Eval("SesionEmisor").ToString() == "True" ? "sent_msg" : "received_msg"%>'>
                                          <div class="received_withd_msg" style='<%# Eval("SesionEmisor").ToString() == "True" ? "display:none" : "" %>'>
                                            <p><%# Eval("Mensaje") %></p>
                                            <span class="time_date"> <%# DateTime.Parse(Eval("FchEnvio").ToString()).ToString("HH:mm tt") %>    |    
                                                <%# DateTime.Parse(Eval("FchEnvio").ToString()).ToString("MMMM dd, yyyy")%>
                                            </span>
                                          </div>

                                          <p style='<%# Eval("SesionEmisor").ToString() == "False" ? "display:none" : "" %>'><%# Eval("Mensaje") %></p>
                                          <span class="time_date" style='<%# Eval("SesionEmisor").ToString() == "False" ? "display:none" : "" %>'>
                                              <%# DateTime.Parse(Eval("FchEnvio").ToString()).ToString("HH:mm tt") %>    |    
                                              <%# DateTime.Parse(Eval("FchEnvio").ToString()).ToString("MMMM dd, yyyy")%>
                                          </span>
                                      </div>
                                  </div>
                              </ItemTemplate>
                          </asp:Repeater>
                        </div>
                      <div class="type_msg">
                        <div class="input_msg_write">
                          <input type="text" class="write_msg" placeholder="Escriba un mensaje" id="txtMessage" runat="server" />
                          <button class="msg_send_btn" type="button" id="btnSendMessage" runat="server" onclick="enviarMensaje()">
                              <i class="fa fa-paper-plane-o" aria-hidden="true"></i>
                          </button>
                          <div style="display:none">
                              <asp:Button ID="btnSendMessageInp" runat="server" OnClick="btnSendMessage_Click" />
                          </div>
                        </div>
                      </div>
                    </div>
                </div>
            </div>
            </div>
        </div>

        <div class="form-group">
            <button class="btn btn-secondary btn-block my-4" name="btnCancelar" onclick="volverAction()">Volver</button>
        </div>
    </div>
</asp:Content>
