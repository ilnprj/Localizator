## Localizator
**Simple Localizator** for Unity3D (works with XML, JSON and CSV files)
- [Current Version 1.2.0 (.unitypackage)](https://gitlab.com/ilnprj/localizator/blob/release/Localizator_v1.2.0.unitypackage)

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
  - Parser that takes localization keys from an json file. This parser works on [SimpleJSON](https://github.com/Bunny83/SimpleJSON) developed by Markus Göbel (Bunny83).
- **LocalizeCSV.cs**
  - Parser that takes localization keys from an CSV file.
- **SwitchTypeParser**
  - Developer may be set type Parsing in this script. 
  - The script can be located in the same scene as the Localizator calls. So in the scene before, for example "Loading" scene.
  - Script sets autofill UI.Dropdown, which fill all available languages. Also Dropdown component auto sets in current lang. 
  - Add loading available languages in Localizator from files .xml, json.
- **Locale**
  - Scripts that provides all load and save parameters to Language (Prefs) 


#### Type of Localization files:
- [Example JSON file](https://gitlab.com/ilnprj/localizator/blob/develop/Assets/Resources/LocJSON.json)
- [Example XML file](https://gitlab.com/ilnprj/localizator/blob/develop/Assets/Resources/LocXML.xml)
- [Example XML file](https://gitlab.com/ilnprj/localizator/blob/develop/Assets/Resources/LocCSV.xml)

#### How to get started?
1.  Set Localization file with all keys and values and put it to Resources folder on your Unity project.
2.  Select type parser (change implementation Parser in script Localizator.cs or add script SwitchTypeParser in scene)
3.  Add in your Text component key - simply only keyword.
4.  Launch your project.
