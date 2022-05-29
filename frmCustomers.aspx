<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmCustomers.aspx.cs" Inherits="frmCustomers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="col-lg-12">
         <div class="panel panel-default">
                <div class="panel-heading">Captura de clientes</div>
               <div class="panel-body">
                   <div class="col-md-6">
                       <form role="form">
                                   <div class="form-group">
                            <label>Cliente *</label>
                            <asp:TextBox ID="txtCliente" autocomplete="false" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                                         <div class="form-group">
                            <label>Prefijo (caracteres permitidos: 5)*</label>
                            <asp:TextBox ID="txtPrefijo" autocomplete="false" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                                                    <div class="form-group">
                            <label>Edificio *</label>
                            <asp:DropDownList CssClass="form-control" ID="ddlEdificio" runat="server"></asp:DropDownList>
                        </div>
                                  <div class="form-group text-center">
                                <asp:LinkButton ID="lnkbtnGuardar" OnClick="lnkbtnGuardar_Click"  CssClass="btn btn-primary" Text="Guardar"  runat="server"  ></asp:LinkButton>
                            </div>
                       </form>
                   </div>

                     <div class="col-lg-6">
                         <asp:GridView ID="gvListadoCustomers" AutoGenerateColumns="false"   runat="server" CssClass="table table-bordered table-hover" Width="99%" >
                             <Columns>
                                 <asp:BoundField DataField="idCustomer" HeaderText="ID" />
                                 <asp:BoundField DataField="customer" HeaderText="Cliente" />
                                 <asp:BoundField DataField="prefix" HeaderText="Prefix" />
                                 <asp:BoundField DataField="building" HeaderText="Edificio" />
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

