<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EdyZada.aspx.cs" Inherits="SZRBD_web.EdyZada" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/css1.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="CentrujacyDIV2">
            <asp:Label ID="Label2" runat="server" Text="Dodawanie Pracownika"></asp:Label>
            <div class="PrzerwaMiedzyLiniami">
                <asp:Label ID="Label1" class="CentrowaneLewe" runat="server" Text="Pracownik"></asp:Label>
                <asp:DropDownList ID="DropDownListPodania2" class="CentrowanePrawe" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPodania2_SelectedIndexChanged">
                </asp:DropDownList>
            </div>

            <div class="PrzerwaMiedzyLiniami">
                <asp:Label ID="Label5" class="CentrowaneLewe" runat="server" Text="Nazwa zadania: "></asp:Label>
                <asp:TextBox ID="TextBox2" CssClass="CentrowanePrawe" runat="server" ></asp:TextBox>
            </div>

            <div class="PrzerwaMiedzyLiniami">
                <asp:CheckBox ID="CheckBox1" runat="server" Text="Zadanie Wykonane?" />
            </div>
            
            <div class="PrzerwaMiedzyLiniami">
                <asp:Button ID="ButtonDodPrW" runat="server" Text="Wróć" OnClick="ButtonDodPrW_Click" />
                <asp:Button ID="ButtonDodPrD" runat="server" Text="Usuń" OnClick="ButtonDodPrU_Click" />
                <asp:Button ID="ButtonDodPrD0" runat="server" Text="Edytuj" OnClick="ButtonDodPrE_Click" />
            </div>
        </div>
        <div class="custompopup" id="divThankYou" runat="server">
        <p>
            <asp:Label ID="lblmessage" runat="server"></asp:Label>
        </p>
        <asp:Button ID="ButtonPopUp" CssClass="classname leftpadding" runat="server" Text="Ok" OnClick="ButtonPopUp_Click1" />
    </div>
        <div class="custompopup" id="div2" runat="server">
        <p>
            <asp:Label ID="Label7" runat="server"></asp:Label>
        </p>
        <asp:Button ID="Button1" CssClass="classname leftpadding" runat="server" Text="Tak" OnClick="ButtonPopUp1tak_Click1" />
            <asp:Button ID="Button2" CssClass="classname leftpadding" runat="server" Text="Nie" OnClick="ButtonPopUp1nie_Click1" />
    </div>
        
        <div class="custompopup" id="div1" runat="server">
        <p>
            <asp:Label ID="Label3" runat="server"></asp:Label>
        </p>
        <asp:Button ID="Button3" CssClass="classname leftpadding" runat="server" Text="Ok" OnClick="ButtonPopUp_Click2" />
    </div>
    </form>
</body>
</html>
