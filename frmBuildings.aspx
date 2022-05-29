<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmBuildings.aspx.cs" Inherits="frmBuildings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="col-lg-12">
         <div class="panel panel-default">
                <div class="panel-heading">Captura de edificios</div>
               <div class="panel-body">
                   <div class="col-md-6">
                       <form role="form">
                                   <div class="form-group">
                            <label>Edificio *</label>
                            <asp:TextBox ID="txtEdificio" autocomplete="false" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                                  <div class="form-group text-center">
                                <asp:LinkButton ID="lnkbtnGuardar" OnClick="lnkbtnGuardar_Click" CssClass="btn btn-primary" Text="Guardar"  runat="server"  ></asp:LinkButton>
                            </div>
                       </form>
                   </div>

                     <div class="col-lg-6">
                         <asp:GridView ID="gvListadoBuildings" AutoGenerateColumns="false" OnPreRender="gvListadoBuildings_PreRender"  runat="server" CssClass="table table-bordered table-hover" Width="99%" >
                             <Columns>
                                 <asp:BoundField DataField="idBuilding" HeaderText="ID" />
                                  <asp:BoundField DataField="Building" HeaderText="Descripción" />
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

