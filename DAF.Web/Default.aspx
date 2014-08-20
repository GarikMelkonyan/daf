<%@ Page Title="DAF - Database Application Framework" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DAF.Web._Default" %>

<asp:Content runat="server" ContentPlaceHolderID="cphWrapper">
    <div class="wrapper">
        <div class="text">
            <span class="tittle">DAF</span>
            <p>
                <span>Database Application Framework</span>
            </p>
            <a href="#" class="button1">More Info</a>
        </div>
        <div id="gallery">
            <ul id="myRoundabout">
                <li>
                    <img src="images/img1.png" alt=""></li>
                <li>
                    <img src="images/img2.png" alt=""></li>
                <li>
                    <img src="images/img3.png" alt=""></li>
            </ul>
        </div>
    </div>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <section class="colFull">
        <h2>Features</h2>
        <asp:DataList runat="server" ID="rptFeatures" OnItemDataBound="rptFeatures_ItemDataBound" 
            RepeatColumns="2" RepeatDirection="Horizontal" RepeatLayout="Table">
            <ItemTemplate>
                <div class="wrapper pad_bot2">
                    <figure class="left marg_right1">
                        <a>
                            <asp:Image runat="server" ID="img" AlternateText='<%# Eval("Title") %>' CssClass="featureImg" />
                        </a>
                    </figure>
                    <p class="pad_bot1 pad_top1">
                        <span class="color1 bold">
                            <asp:Literal runat="server" Text='<%# Eval("Title") %>' />
                        </span>
                    </p>
                    <p>
                        <asp:Literal runat="server" Text='<%# Eval("Description") %>' />
                    </p>
                </div>
            </ItemTemplate>
        </asp:DataList>

    </section>

    <section class="colFull">
        <h2 class="pad_bot1">What We Offer</h2>
        <div class="wrapper">
            <figure class="left marg_right1">
                <img src="images/page1_img4.jpg" alt="">
            </figure>
            <p class="pad_top1 pad_bot1"><strong class="color1">This is one of free website templates created by TemplateMonster.com</strong></p>
            <p class="pad_bot3">This Pro Soft template is optimized for 1024X768 screen resolution.It has several pages: <a href="index.html">Home Page</a>, <a href="features.html">Features</a>, <a href="support.html">Support</a>, <a href="downloads.html">Downloads</a>, <a href="contacts.html">Contacts</a> (note that contact us form – doesn’t work).</p>
            <a href="#" class="button right">Read More</a>
        </div>
        <h2 class="pad_bot1 pad_top1">Why Do You Need It?</h2>
        <div class="wrapper">
            <figure class="left marg_right1">
                <img src="images/page1_img5.jpg" alt="">
            </figure>
            <p class="pad_top1 pad_bot1"><strong class="color1">This Pro Soft Template goes with two packages</strong></p>
            <p class="pad_bot3">With PSD source files and without them. PSD source files are available for free for the registered members of Templates.com. The basic package (without PSD source is available for anyone without registration).</p>
            <a href="#" class="button right">Read More</a>
        </div>
    </section>
</asp:Content>
