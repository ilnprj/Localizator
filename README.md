## Localizator
**Simple Localizator** for Unity (works with XML, JSON and CSV files)
- [Current Version 1.3.0 (.unitypackage)](https://github.com/ilnprj/Localizator/blob/release/Localizator_v1.3.0.unitypackage)

#### Features:
- Can translate one key or several in one component.
- Text Component may contain not only the key for translation.
- Automatic translation of keys into runtime when the user changes the language.
- Simple select between different system of localization library (XML,JSON,CSV).
- Static localizator, dont need put controller into the scene, just text component.

#### Main scripts:
- **Localizator.cs**
  - Main static class.
- **GetLocalizeText.cs**
  - A component that is bound to UI.Text and that sets localized text by one or several keys.
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
- [Example JSON file](https://github.com/ilnprj/Localizator/blob/master/Assets/Resources/LocJSON.json)
- [Example XML file](https://github.com/ilnprj/Localizator/blob/master/Assets/Resources/LocXML.xml)
- [Example CSV file](https://github.com/ilnprj/Localizator/blob/master/Assets/Resources/LocCSV.csv)

#### How to get started?
1.  Set Localization file with all keys and values and put it to Resources folder on your Unity project. (XML or JSON or CSV)
2.  Select type parser (change implementation Parser in script Localizator.cs or add script SwitchTypeParser in scene and select public enum)
3.  Add Text Component (Canvas)
4.  Set your text in Text Component and put your keys or one key for localize into scopes [] (Example: `[Play] 12354 [Now]`)
5.  Launch your project.
