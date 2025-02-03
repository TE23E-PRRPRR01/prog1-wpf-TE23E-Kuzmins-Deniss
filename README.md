[![Open in Visual Studio Code](https://classroom.github.com/assets/open-in-vscode-2e0aaae1b6195c2367325f4f02e2d04e9abb55f0b24a779b69b11b9e10269abc.svg)](https://classroom.github.com/online_ide?assignment_repo_id=17998198&assignment_repo_type=AssignmentRepo)
# C# i Visual Studio Code
VS Code är en snabbt och lättanvänt IDE som du kan skapa ditt C#-projekt med.

## Förberedelser

### Installera och ställ in VS Code

* Installera [Dotnet 8](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-8.0.404-windows-x64-installer)

### Installera följande tillägg i VS Code

* [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) – Ger VS Code stöd för C#
* [C# Toolbox of Productivity](https://marketplace.visualstudio.com/items?itemName=RichardZampieriprog.csharp-snippet-productivity) – Lägger till en del extra användbara genvägar och funktioner, tex för att skapa nya projekt och klasser
* [Open Folder Context Menu](https://marketplace.visualstudio.com/items?itemName=chrisdias.vscode-opennewinstance) - För att enkelt öppna en mapp
* [gitignore](https://marketplace.visualstudio.com/items?itemName=codezombiech.gitignore) – Underlättar arbetet med git och VS Code. Om du söker efter den, se till att ta den av CodeZombie!
* [VSCode Great Icons](https://marketplace.visualstudio.com/items?itemName=emmanuelbeziat.vscode-great-icons) – Gör det lättare att känna igen filtyper
* [RedHat XML](https://marketplace.visualstudio.com/items?itemName=redhat.vscode-xml) - För att jobba med WPF och Xaml
* [C# XML Documentation Comments](https://marketplace.visualstudio.com/items?itemName=k--kato.docomment) - För att kommentera metoder och klasser

### VS Code inställningar

* Slå **Ctrl + Skift + P** och **Open User Settings (JSON)**
* Klistra in följande:

```JSON
,
"files.associations": {
    "*.xaml": "xml"
},
"xml.fileAssociations": [
    {
        "pattern": "**/*.xaml",
        "systemId": "https://raw.githubusercontent.com/karye/xamelot/refs/heads/master/syntax/xaml.xsd"
    }
],
```

### VS Code Snippet

* Slå **Ctrl + Skift + P** och **Snippets: Configure Snippets**
* Välj **New Global Snippets File ...**
* Klistra in följande:

```JSON
{
    "XAML event": {
		"prefix": "event",
		"body": [
			"private void $1(object sender, RoutedEventArgs e)",
			"{",
			"\t$2",
			"}"
		],
		"description": "Metod för att fånga event från XAML"
	}
}
```

## Skapa C#-projekt

1. Skapa en ny mapp
2. Öppna den tomma mappen i **VS Code**
3. Öppna en ny terminal (ctrl + ö)
4. Skapa grundkoden med:

```bash
dotnet new wpf
```
4. Koda och testa med:

```bash
dotnet run
```

## Ladda upp till GitHub

1. Tryck på ikonen för Source Control
2. Fyll i en commit meddelande som beskriver vad du har gjort
3. Tryck på **Commit & Sync**
