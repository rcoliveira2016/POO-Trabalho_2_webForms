<%@ Page Title="Cadastro Cliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Trabalho_2_webForms.Paginas.Clientes.Cadastro" %>
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
            <label for="txtCPF">CPF</label>
            <asp:TextBox CssClass="form-control" runat="server" ID="txtCPF" />
        </div>
        <div class="form-group">
            <label for="txtEndereco">Endereço</label>
            <asp:TextBox CssClass="form-control" runat="server" ID="txtEndereco" />
        </div>
         <div class="form-group">
            <label for="txtTelefone">Telefone</label>
            <asp:TextBox CssClass="form-control" TextMode="Phone" runat="server" ID="txtTelefone" />
        </div>
        <div class="form-group">
            <label for="txtTelefone">Data Nascimento</label>
            <asp:TextBox CssClass="form-control" TextMode="Date" runat="server" ID="txtDataNascimento" />
        </div>
        <asp:Button runat="server" Text="Salvar" ID="btnSalvar" CssClass="btn btn-default" OnClick="btnSalvar_Click" />
    </fieldset>
</asp:Content>
