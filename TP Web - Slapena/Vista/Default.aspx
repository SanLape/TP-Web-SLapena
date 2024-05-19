<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Vista.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <hr /> 
    <div class="row">    
            <div class="col-10">
                <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control me-2">NOMBRE DE PORDUCTO</asp:TextBox>
            </div>
            <div class="col-2">
                <asp:Button ID="btnBuscar" runat="server" Text="BUSCAR" OnClick="btnBuscar_Click" CssClass="btn btn-success" />
            </div>       
    </div>

    <hr />

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card" style="width: 18rem;">
                        <img src="<%#Eval("imagen.urlImagen") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("nombre") %></h5>
                            <p class="card-text"><%#Eval("descripcion") %></p>
                            <a href="DetalleArticulo.aspx?id=<%#Eval("idArticulo") %>" class="btn btn-primary">DETALLE</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
