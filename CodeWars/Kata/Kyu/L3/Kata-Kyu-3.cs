using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace CodeWars {
    public partial class KataClass {

        /// <summary>Интерактивное создание класса</summary>
        /// <param name="className">Имя класса</param>
        /// <param name="properties">Свойства класса (имя, тип)</param>
        /// <param name="actualType"></param>
        /// <returns>false, если класс уже существует в этой сборке</returns>
        [KataType(LevelTypes.Kyu, 3, "589394ae1a880832e2000092")]
        public static bool DefineClass(string className, Dictionary<string, Type> properties, ref Type actualType) {
            TypeBuilder tb = GetTypeBuilder(className);
            var gType = Assembly.GetExecutingAssembly().GetType(className);
            if (gType != null) return false;
            foreach (KeyValuePair<string, Type> member in properties) {
                var fieldBuilder = tb.DefineProperty(member.Key, PropertyAttributes.HasDefault, member.Value, null);
            }
            actualType = tb.CreateType();
            return true;
        }

        private static TypeBuilder GetTypeBuilder(string typeName) {
            AssemblyName an = Assembly.GetExecutingAssembly().GetName();
            //var an = new AssemblyName(); //Новый идентификатор динамической сборки
            //Создание динамической сборки для динамического класса
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(typeName);
            return moduleBuilder.DefineType(typeName,
              TypeAttributes.Public |
              TypeAttributes.Class |
              TypeAttributes.AutoClass |
              TypeAttributes.AnsiClass |
              TypeAttributes.BeforeFieldInit |
              TypeAttributes.AutoLayout,
              null);
        }

        private static void CreateProperty(TypeBuilder tb, string propertyName, Type propertyType) {
            FieldBuilder fieldBuilder = tb.DefineField("_" + propertyName, propertyType, FieldAttributes.Private);

            PropertyBuilder propertyBuilder = tb.DefineProperty(propertyName, PropertyAttributes.HasDefault, propertyType, null);
            MethodBuilder getPropMthdBldr = tb.DefineMethod("get_" + propertyName, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, propertyType, Type.EmptyTypes);
            ILGenerator getIl = getPropMthdBldr.GetILGenerator();

            getIl.Emit(OpCodes.Ldarg_0);
            getIl.Emit(OpCodes.Ldfld, fieldBuilder);
            getIl.Emit(OpCodes.Ret);

            MethodBuilder setPropMthdBldr =
                tb.DefineMethod("set_" + propertyName,
                  MethodAttributes.Public |
                  MethodAttributes.SpecialName |
                  MethodAttributes.HideBySig,
                  null, new[] { propertyType });

            ILGenerator setIl = setPropMthdBldr.GetILGenerator();
            Label modifyProperty = setIl.DefineLabel();
            Label exitSet = setIl.DefineLabel();

            setIl.MarkLabel(modifyProperty);
            setIl.Emit(OpCodes.Ldarg_0);
            setIl.Emit(OpCodes.Ldarg_1);
            setIl.Emit(OpCodes.Stfld, fieldBuilder);

            setIl.Emit(OpCodes.Nop);
            setIl.MarkLabel(exitSet);
            setIl.Emit(OpCodes.Ret);

            propertyBuilder.SetGetMethod(getPropMthdBldr);
            propertyBuilder.SetSetMethod(setPropMthdBldr);
        }

    }

}

