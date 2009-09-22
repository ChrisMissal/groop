<%@ Page Language="C#" MasterPageFile="~/Views/Layouts/Default.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="CRIneta.Web.Core.Domain"%>

<asp:Content runat="server" ContentPlaceHolderID="headerContent">
<style type="text/css">
.officers dl
{
	margin-top: 0;
}
.officers dt 
{
	display: block;
	width: 90%;
	font-size: 125%;
	margin: 1.5em 0 1ex;
	border-bottom: 1px solid #666;
	overflow: hidden;
	float: left;
	clear: both;
}
.officers dt > strong
{
	font-size: 110%;
	font-weight: bold;
}
.officers dd
{
	overflow: hidden;
	clear: both;
}
.officers dd > p
{
	padding: 1em auto 0;
}
.officers img
{
	display: block;
	float: left;
	max-width: 135px;
	margin: 1ex 1em 1ex 0;
}
.officers blockquote
{
	display: block;
	clear: both;
	font-style: oblique;
}
</style>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="mainContent">
	<div class="officers post">
	    <h2 class="title">CRineta Officers</h2>
	    <div class="entry">
            <dl>
                <dt><strong>President:</strong> Tim Barcz</dt>
                <dd>
                    <img src="<%= AppHelper.ImageUrl("officers/TimBVS.jpg") %>" alt="Tim Barcz" />
                    <p>Tim has been working as a software professional for the last 8 years. He has a breath of software experience which has ranged from embedded systems written in C for micro controllers to windows applications with C++ and MFC to most recently web application work in the .NET platform.</p>
                    <p>Tim has a passion for learning and sharing what he's learned with others. In addition to personal growth, he enjoys working with developers to see their skill increase through the adoption of engineering principles and practices. He takes great pride in seeing developers have their "aha" moment. As such he enjoys the opportunity to blog, speak at various code camps, and work on the leadership team of the CRIneta .NET user group.</p>
                    <blockquote><strong>Tim says:</strong> Great design is asking to hear the answer to a riddle and then thinking, "duh! of course"</blockquote>
                </dd>
                
                <dt><strong>Vice President:</strong> Bill Koozer</dt>
                <dd>
                    <img src="<%= AppHelper.ImageUrl("officers/BillKVS.jpg") %>" alt="Bill Koozer" />
                    <p>Bill has over 10 years of Information Technology experience across a variety of industries. He has been programming with .NET almost exclusively since 2002, with the occasional foray into Perl and other languages. His experience in .NET includes both Web and Windows-based development using C#,VB.NET and ASP.NET and SQL Server.</p>
                    <blockquote><strong>Bill says:</strong> .NET is a great development platform. It offers a lot of power, yet it lets me focus primarily on solving business problems rather than learning or memorizing complex and arcane APIs. CRINETA is a great way to meet other developers and learn more about .NET and ways it can help developers to be more effective.</blockquote>
                </dd>
                
                <dt><strong>Community Development &amp; Sponsorship:</strong> Chris Sutton</dt>
                <dd>
                    <img src="" alt="Chris Sutton" />
                    <p>Chris is a software developer with over 7 years of experience developing web applications.  He has invested the last four years developing production applications with the .Net Framework and Asp.Net.  Chris has worked developing insurance illustration systems, leading edge commercial real estate listing tools and tools for managing the floral importing and distribution process.</p>
                    <p>Some of his current interests include ASP.Net MVC and C# 3.0.  He is also actively working with Continuous Integration tools and concepts and agile methodologies.  Chris is a trainer and developer for New Horizons in Cedar Rapids.</p>
                    <blockquote><strong>Chris says:</strong> I'm excited to see user group communities grow and develop around the great .Net tools that have come out in recent years.  Every time people participate in user groups they contribute to the quality and future of the technolgies we use.</blockquote>
                </dd>
                
                <dt><strong>INETA Liaison/Speakers:</strong> Greg Sohl</dt>
                <dd>
                    <img src="<%= AppHelper.ImageUrl("officers/GregSVS.jpg") %>" alt="Greg Sohl" />
                    <p>Greg is a solution architect with Fiserv, Inc. in Cedar Rapids. Working daily in .NET from both an architecture and development perspective, he enjoys the opportunities the group affords to gain knowledge from peers and to share ideas.</p>
                </dd>
                
                <dt><strong>Secretary:</strong> Zac Harlan</dt>
                <dd>
                    <img src="<%= AppHelper.ImageUrl("officers/ZacHVS.jpg") %>" alt="Zac Harlan" />
                    <p>Zac is a programmer analyst with over 5 years of software development and project management experience. Zac is currently working as a programmer analyst at Thomas L Cardella and Associates in Cedar Rapids Iowa where he works in the .net framework daily.  He prefers to do web development but has also gotten his feet wet in the SSIS world as well.</p>
                    <blockquote><strong>Zac says:</strong> I am very excited to see this group grow into a community where everyone feels comfortable learning from their peers.</blockquote>
                </dd>
                
                <dt><strong>Webmaster/Communications:</strong> Chris Missal</dt>
                <dd>
                    <img src="<%= AppHelper.ImageUrl("officers/ChrisMissal.jpg") %>" alt="Chris Missal" />
                    <p>Chris has spent most of his professional career in the .Net world, primarily in web applications. While blogging/writing/reading mostly about web related technologies, he still enjoys learning about anything related to software development.</p>
                    <p>While working on an agile software development team at J&amp;P Cycles in Anamosa, IA, Chris enjoys being able to work on code and new features that reaches thousands of web site users within days of inception.</p>
                    <blockquote><strong>Chris says:</strong> This group gets better each month. The members seem to really care about improving their craft and helping others improve theirs as well.</blockquote>
                </dd>
            </dl>
        </div>
        <%-- Chris Missal: These were already added before I read the email thread that we decided not to
                            include former officers. I would delete these, but as a precationary measure
                            (not knowing many of these guys), I'm going to leave them commented out, in the
                            case that somebody throws a fuss about not being included anymore.
                            
        <h2 class="title">Former Officers</h2>
        <div class="entry">
            <dl>
                <dt>Dave Paris</dt>
                <dd>
                    <img src="<%= AppHelper.ImageUrl("officers/dpVS.jpg") %>" alt="Dave Paris" />
                    <p>Since moving to the Cedar Rapids area in the winter of 1999, Dave has worked for companies like Lason Inc and Omnilingua, and is currently employed at the AdTrack Corporation as a Software Engineer. His background includes work in Paradox, Access/VBA, VB6, classic ASP, and HTML. Since 2001 Dave has done application and web programming in VB.NET, C# and ASP.NET with SQL Server. Dave is also an extremely versatile guitarist, and maintains his own website at www.daveparis.com for his music.</p>
                    <blockquote><strong>Dave says:</strong> The .NET User's Group is a perfect opportunity to learn and interact with some of the best developers in our area, and I'm honored to be a part of this group...the free food and giveaways don't hurt either!</blockquote>
                </dd>
                
                <dt>Jason Brunken</dt>
                <dd>
                    <img src="<%= AppHelper.ImageUrl("officers/jbrunken.jpg") %>" alt="Jason Brunken" />
                    <p>Jason has 8 years of experience in Web Development using technologies such as: ASP.NET, C#, VB.NET, ASP, Javascript, PERL, XML and MSSQL.  Formerly a software consultant, Jason worked with a number of companies to implement .NET solutions for E-Commerce sites, HR applications and project management tools.  Jason now works for Decisionmark, where he assisted with the migration to .NET.  He is one of the lead software engineers for TitanTV.com.</p>
                    <blockquote><strong>Jason says:</strong> When I first started to work with the VS.NET beta, it was clear to me that .NET was the future for web based development on the Microsoft platform.  I jumped in with both feet and it's enabled me to quickly implement solutions to problems that would have been nearly impossible with “legacy” technologies like ASP or PERL.</blockquote>
                </dd>
                
                <dt>Mike Jackson</dt>
                <dd>
                    <img src="<%= AppHelper.ImageUrl("officers/Mike002.jpg") %>" alt="Mike Jackson" />
                    <p>Mike has been building desktop and web applications with Microsoft tools for ten years.  He is a Microsoft Certified Solution Developer, Database Administrator, and Trainer.  He worked for seven years as a trainer/consultant for New Horizons and currently works for Eagle Technology Management.</p>
                    <blockquote><strong>Mike says:</strong> I am incredibly satisfied and very exited about .NET.  It has brought some fun back to the business.</blockquote>
                </dd>
                
                <dt>Travis Wilson</dt>
                <dd>
                    <img src="<%= AppHelper.ImageUrl("officers/Travis2.JPG") %>"
                    <p>Travis has been programming for nearly 15 years, beginning with dBase II/III+ and DOS development with CA-Clipper. He has developed in C on AIX UNIX, and is currently programming in DEC BASIC for The CBE Group in Waterloo, IA. He helped pioneer the use of .NET at CBE and has assisted in the development of their Client Internet Access tool using ASP.NET. CBE is currently working to rewrite their Receivables Management software and other internal applications in .NET.</p>
                    <blockquote><strong>Travis says:</strong> We see the promise of .NET and are working hard to make the leap from mainframe programming to Windows. We're still learning, but it's added some fun to our work and reminded some of us why we were interested in becoming programmers in the first place.</blockquote>
                </dd>
                
                <dt>Eric Johnson</dt>
                <dd>
                    <img src="<%= AppHelper.ImageUrl("officers/eric.jpg") %>" alt="Eric Johnson" />
                    <p>Former CRINETA President and Microsoft Alumni, Eric is now working for Rockwell Collins as an Enterprise Solution Architect.  Now that's he no longer on the road for Microsoft, he looks forward to re-engaging with the group.  Over the the last 9 years he's worked for AEGON, Infinitly Marketing Solutions, Aerotek, Siemens Transportation Systems, Siemens VDO Automotive, QCI, Volt Informance Sciences, and Microsoft.  He's also worked with Fastek, Y1 Solutions, and New Horizons through 1099 and corp-to-corp consulting.</p>
                    <p>He specializes in architecture/development for Web, Middleware, Portals, Collaboration, and ILM solutions.  He's experienced in Web, Windows, Services, and Middleware applications using technologies such as: ASP.NET, C#, WCF, WSE, Remoting, COM, DCOM, Sharepoint, DNN, VB.NET, ASP, Java, C++, VB, XML, Oracle and SQL Server.</p>
                    <p>Eric is an experienced presenter and works with other user groups, INETA, and Microsoft for activities such as: conference planning, regional events, beta programs, and Microsoft briefings. He's well connected with Microsoft, a board member of Heartland Developers Network, and a member of the INETA Community Activities Team.   You can see what he’s up to lately by reading his blog at www.geekswithblogs.net/ericjohnson.</p>
                    <blockquote><strong>Eric says:</strong> It's good to be off the road...  I'm commited to developing leaders and technology evangelists throughout Eastern Iowa and CRineta is a great avenue to do so!</blockquote>
                </dd>
            </dl>
		</div>
		--%>
	</div>
</asp:Content>
