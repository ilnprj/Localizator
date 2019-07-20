## Localizator
**Simple Localizator** for Unity3D (works with XML, JSON files)

#### Features:
- **Localizator.cs**
  - Main static class.
- **GetLocalizeText.cs**
  - A component that is bound to UI.Text and that sets localized text by key.
- **IParseableLocalize.cs**
  - All parsers of any type must implement this interface. The interface is set to Localizator.
- **LocalizeXML.cs**
  - Parser that takes localization keys from an xml file and returns them to Localizator class.
- **LocalizeJSON.cs**
  - Parser that takes localization keys from an json file. This parser works on [SimpleJSON](https://github.com/Bunny83/SimpleJSON).
- **SwitchTypeParser**
  - Developer may be set type Parsing in this script. ***Also this script must be set on another scene or must be activated before first call GetLocalizeText script***.


#### Type of Localization files:
- [Example JSON file](https://gitlab.com/ilnpj/localizator/blob/develop/Assets/Resources/LocJSON.json)
- [Example XML file](https://gitlab.com/ilnpj/localizator/blob/develop/Assets/Resources/LocXML.xml)

#### How to get started?
1.  Set Localization file with all keys and values and put it to Resources folder on your Unity project.
2.  Select type parser (change implementation Parser in script Localizator.cs or add script SwitchTypeParser in scene)
3.  Add in your Text component key - simply only keyword.
4.  Launch your project.
