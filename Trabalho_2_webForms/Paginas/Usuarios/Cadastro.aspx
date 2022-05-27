<%@ Page Title="Cadastro Cliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Trabalho_2_webForms.Paginas.Usuarios.Cadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset class="titulo-pagina">
        <legend><%: Title %></legend>
        <div class="form-group">
            <label for="txtNome">Id</label>
            <asp:TextBox CssClass="form-control" Enabled="false" runat="server" ID="txtId" />
        </div>
        <div class="form-group">
            <label for="txtNome">Nome</label>
            <asp:TextBox CssClass="form-control" runat="server" ID="txtNome" />
        </div>
        <div class="form-group">
            <label for="txtLogin">Login</label>
            <asp:TextBox CssClass="form-control" runat="server" ID="txtLogin" />
        </div>
        <div class="form-group">
            <label for="txtEndereco">Senha</label>
            <asp:TextBox CssClass="form-control" runat="server" ID="txtSenha" />
        </div>
        <asp:Button runat="server" Text="Salvar" ID="btnSalvar" CssClass="btn btn-default" OnClick="btnSalvar_Click" />
    </fieldset>
</asp:Content>
