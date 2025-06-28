<h1>Case Registration System</h1>
A multi‑tier application that allows a company to register working hours on departmental cases. The solution showcases a clean 3‑layer architecture, sharing one domain across multiple UIs: an ASP.NET MVC web app for time registration and a WPF desktop app for administration.



<h2>Tech Stack</h2>
<ol>
<li>.NET 8 (adjust if using another version)</li>

<li>ASP.NET MVC 5</li>

<li>WPF (.NET)</li>

<li>Entity Framework 6.x – Code‑First + Migrations</li>

<li>SQL Server (LocalDB)</li>

<li>AutoMapper‑style manual mappers</li>

<li>XAML & MVVM in WPF</li>
</ol>

<h2>Getting Started</h2>

<strong>Prerequisites</strong>

Visual Studio 2022 or newer

.NET SDK 8.0

SQL Server Express (LocalDB comes with VS)

For Remote DB: Remember to input IP & change DB credentials

# Open the solution in Visual Studio
TimeRegistration.sln

The first build will create a RegistreringsSystem database and seed demo data automatically.

### Run the apps

In Solution Properties set multiple startup projects:

MVCApp → Start

WpfApp → Start

Press F5. The MVC site opens in your browser, and the WPF admin launches.
