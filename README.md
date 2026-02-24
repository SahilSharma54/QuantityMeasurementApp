## 📘 UC1 — Feet Measurement Equality

### Description

UC1 verifies equality between two length measurements in **feet** using a service-based design.
The application compares both **value** (with tolerance for floating-point precision) and **unit**.

---

### ✅ Preconditions

* `LengthMeasure` objects are created.
* Both measurements use the **FEET** unit.

---

### 🔄 Main Flow

1. Create two `LengthMeasure` objects using `LengthMeasure.Feet(value)`.
2. Pass the objects to `LengthEqualityService`.
3. Service validates null inputs.
4. Values are compared using tolerance (`0.0001`).
5. Units are compared.
6. Result (true / false) is returned.

---

### 📌 Postconditions

Returns **true** when both value and unit match; otherwise **false**.

---

### 🧩 Implementation Overview

* **Model:** `LengthMeasure`

  * Immutable object storing `Value` and `Unit`.
  * Factory method for feet creation.

* **Service:** `LengthEqualityService`

  * Handles equality logic.
  * Includes null safety.
  * Uses tolerance for floating-point comparison.

---

### 🧪 Tests (NUnit)

* `ZeroFeet_ShouldBeEqual`
* `SameFeet_ShouldBeEqual`
* `DifferentFeet_ShouldNotBeEqual`

Tests verify value-based equality using the service.

---

### 📁 Project Structure

```
QuantityMeasurementApp
├── Models
│   └── LengthMeasure.cs
├── Services
│   └── LengthEqualityService.cs
└── QuantityMeasurementApp.Tests
    └── LengthEqualityServiceTests.cs
```

---

### 🎯 Concepts Covered

* Value-based equality
* Floating-point tolerance comparison
* Null safety
* Service-based design
* Unit testing with NUnit
