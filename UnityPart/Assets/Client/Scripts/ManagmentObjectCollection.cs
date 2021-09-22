using System.Collections.Generic;

namespace Client.Scripts
{
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Options
    {
        public string Locale { get; set; }
        public object Username { get; set; }
        public string Authority { get; set; }
        public int Impersonation { get; set; }
        public int Authentication { get; set; }
        public bool EnablePrivileges { get; set; }
        public List<object> Context { get; set; }
        public string Timeout { get; set; }
        public bool UseAmendedQualifiers { get; set; }
    }

    public class Path
    {
        public string path { get; set; }
        public string RelativePath { get; set; }
        public string Server { get; set; }
        public string NamespacePath { get; set; }
        public string ClassName { get; set; }
        public bool IsClass { get; set; }
        public bool IsInstance { get; set; }
        public bool IsSingleton { get; set; }
    }

    public class Scope
    {
        public bool IsConnected { get; set; }
        public Options Options { get; set; }
        public Path Path { get; set; }
    }

    public class ClassPath
    {
        public string Path { get; set; }
        public string RelativePath { get; set; }
        public string Server { get; set; }
        public string NamespacePath { get; set; }
        public string ClassName { get; set; }
        public bool IsClass { get; set; }
        public bool IsInstance { get; set; }
        public bool IsSingleton { get; set; }
    }

    public class Qualifier
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public bool IsAmended { get; set; }
        public bool IsLocal { get; set; }
        public bool PropagatesToInstance { get; set; }
        public bool PropagatesToSubclass { get; set; }
        public bool IsOverridable { get; set; }
    }

    public class Property
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public int Type { get; set; }
        public bool IsLocal { get; set; }
        public bool IsArray { get; set; }
        public string Origin { get; set; }
        public List<Qualifier> Qualifiers { get; set; }
    }

    public class SystemProperty
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public int Type { get; set; }
        public bool IsLocal { get; set; }
        public bool IsArray { get; set; }
        public string Origin { get; set; }
        public List<object> Qualifiers { get; set; }
    }

    public class ManagementObjectCollection
    {
        public Scope Scope { get; set; }
        public Path Path { get; set; }
        public Options Options { get; set; }
        public ClassPath ClassPath { get; set; }
        public List<Property> Properties { get; set; }
        public List<SystemProperty> SystemProperties { get; set; }
        public List<Qualifier> Qualifiers { get; set; }
        public object Site { get; set; }
        public object Container { get; set; }
    }

}