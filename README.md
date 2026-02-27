📏 Quantity Measurement App — UC3 (Generic Quantity)
📌 Description

UC3 refactors the separate Feet and Inch implementations into one generic class QuantityLength, following the DRY principle.

A LengthUnit enum is introduced and equality is handled using a common base unit conversion.

🎯 Objective

Remove duplicate code from UC1 and UC2

Create a generic quantity class

Support cross-unit comparison (1 Foot = 12 Inches)

Improve maintainability and scalability

🏗 Implementation

LengthUnit enum → defines units

QuantityLength class → stores value + unit

Equality → converts values to base unit before comparison

Example:

1 Foot == 12 Inch → true
🧪 Tests

Same unit equality

Cross-unit equality

Different values inequality

Null & reference checks

🚀 Run
git checkout feature/UC3-GenericQuantity
dotnet test
✅ Result

UC3 removes duplication and makes the system scalable for adding new units like Meter, Yard, etc.
