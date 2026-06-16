# Issue AZ7PZpH4IRleBA2bjxW0

- Rule: csharpsquid:S1192
- Severity: MINOR
- File: 6_Ideation/Data/generator/HelperMethodsGenerator.cs
- Line: 39
- Message: Define a constant instead of using this literal '        /// <summary>' 8 times.
- Status: Fixed

## Fix

Replaced all inline `"        /// <summary>"` literals in AppendSerialize2DArrayMethod, AppendSerializeCollectionMethod, AppendSerializeDictionaryMethod, AppendDeserializeArrayMethod, AppendDeserialize2DArrayMethod, AppendDeserializeListMethod, and AppendDeserializeDictionaryMethod with the existing `XmlSummary` constant.
