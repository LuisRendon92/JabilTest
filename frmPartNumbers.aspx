<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmPartNumbers.aspx.cs" Inherits="frmPartNumbers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
           <div class="col-lg-12">
         <div class="panel panel-default">
                <div class="panel-heading">Captura de No. parte</div>
               <div class="panel-body">
                   <div class="col-md-6">
                       <form role="form">
                                   <div class="form-group">
                            <label>No. parte *</label>
                            <asp:TextBox ID="txtNoParte" autocomplete="false" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                       <div class="form-group">
                            <label>Cliente *</label>
                            <asp:DropDownList CssClass="form-control" ID="ddlCustomer" runat="server"></asp:DropDownList>
                        </div>
                                  <div class="form-group text-center">
                                <asp:LinkButton ID="lnkbtnGuardar" OnClick="lnkbtnGuardar_Click"  CssClass="btn btn-primary" Text="Guardar"  runat="server"  ></asp:LinkButton>
                            </div>
                       </form>
                   </div>

                     <div class="col-lg-6">
                         <div class="col-md-12" style="margin-bottom:2em;">
                                   <label>Filtar por estatus:</label>
                          <asp:DropDownList CssClass="form-control" ID="ddlEstatus" runat="server" OnSelectedIndexChanged="ddlEstatus_SelectedIndexChanged" AutoPostBack="true">
                              <asp:ListItem Value="2"> -- Todos --</asp:ListItem>
                              <asp:ListItem Value="1"> Activos</asp:ListItem>
                              <asp:ListItem Value="0"> Inactivos</asp:ListItem>
                          </asp:DropDownList>
                         </div>

                         <div class="col-lg-1" style="margin-bottom:1em;">
                              <asp:LinkButton ID="lnkExportar" OnClick="lnkExportar_Click"  CssClass="btn btn-success" Text="Exportar"  runat="server"  ></asp:LinkButton>
                         </div>
                   
                         <asp:GridView ID="gvListado" AutoGenerateColumns="false"   runat="server" CssClass="table table-bordered table-hover" Width="99%" >
                             <Columns>
                                 <asp:BoundField DataField="idPartNumber" HeaderText="ID" />
                                 <asp:BoundField DataField="partNumber" HeaderText="No. Parte" />
                                 <asp:BoundField DataField="customer" HeaderText="Cliente" />
                                 <asp:BoundField DataField="building" HeaderText="Edificio" />
                                 <asp:BoundField DataField="estatus" HeaderText="Estatus" />
                             </Columns>
                             <EmptyDataTemplate>
                                 <div class="col-md-12 text-center">Sin registros...</div>
                             </EmptyDataTemplate>
                         </asp:GridView>
                     </div>

               </div>
         </div>
     </div>
</asp:Content>

