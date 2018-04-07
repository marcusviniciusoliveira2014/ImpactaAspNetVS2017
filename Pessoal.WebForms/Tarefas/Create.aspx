<%@ page title="" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" codefile="Create.aspx.cs" inherits="Tarefas_Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <h1>Nova Tarefa</h1>
    <hr />

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" />
    
    <table style="width: 100%;">
        <tr>
            <td>Nome</td>
            <td>
                <asp:TextBox ID="NomeTextBox" runat="server" Width="246px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NomeTextBox" CssClass="text-danger" ErrorMessage="O Nome é obrigatório" SetFocusOnError="True">(!)</asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Prioridade</td>
            <td>
                <asp:DropDownList ID="PrioridadeDropDownList" AppendDataBoundItems="true" runat="server" DataSourceID="ObjectDataSource1" Height="24px" Width="89px">
                    <asp:ListItem Text="Selecione ..." Value="0"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PrioridadeDropDownList" CssClass="text-danger" ErrorMessage="Selecione uma prioridade" InitialValue="0" SetFocusOnError="True">(!)</asp:RequiredFieldValidator>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ObterPrioridades" TypeName="Pessoal.WebForms.Helper"></asp:ObjectDataSource>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Concluida</td>
            <td>
                <asp:CheckBox ID="ConcluidaCheckBox" runat="server" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Observação</td>
            <td>
                <asp:TextBox ID="ObservacaoTextBox" runat="server" Rows="5" TextMode="MultiLine" Width="249px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>

    </table>
    <asp:Button ID="gravarButton" runat="server" Text="Gravar" OnClick="gravarButton_Click" />
    

</asp:Content>

