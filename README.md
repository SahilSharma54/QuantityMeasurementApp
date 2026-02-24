## 📘 UC2 — Inch Measurement Equality

### Description

UC2 adds support for **inch measurement equality**.
The application compares two `LengthMeasure` objects and returns true only when both the **value** and **unit (INCH)** are the same.

---

### ✅ Preconditions

* Two measurements are created using `LengthMeasure.Inch(value)`.
* Both measurements must use the same unit.

---

### 🔄 Main Flow

1. Create two inch measurements using the factory method.
2. Pass them to `LengthEqualityService`.
3. Service checks for null inputs.
4. Service ensures both units match.
5. Values are compared using tolerance (`0.0001`).
6. Equality result is returned.

---

### 📌 Postconditions

* Returns **true** when inch values and units match.
* Returns **false** when values differ or units differ.
* Feet and inch measurements are not equal.

---

### 🧩 Implementation Overview

* Added `Inch(value)` factory method in `LengthMeasure`.
* Updated `LengthEqualityService` to enforce same-unit comparison.
* Value comparison uses tolerance to handle floating-point precision.

---

### 🧪 Tests (NUnit)

* `SameInch_ShouldBeEqual`
* `DifferentInch_ShouldNotBeEqual`
* `FeetAndInch_ShouldNotBeEqual`

---

### 📁 Project Structure

QuantityMeasurementApp
├── Models
│   └── LengthMeasure.cs
├── Services
│   └── LengthEqualityService.cs
└── QuantityMeasurementApp.Tests
└── LengthEqualityServiceTests.cs

---

### 🎯 Concepts Covered

* Multi-unit support
* Unit-based equality rules
* Floating-point tolerance comparison
* Null safety
* Unit testing with NUnit
