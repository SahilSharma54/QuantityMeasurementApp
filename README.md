## UC4 — Add Volume Measurement Using Generic Quantity

### 📌 Description

UC4 extends the generic quantity design introduced in UC3 by adding support for **Volume measurements**.
This ensures that the application follows the **DRY principle** by reusing the same generic quantity logic instead of creating separate classes for each measurement type.

This use case introduces new units such as **Liters** and **Gallons** while maintaining consistent equality comparison using a common base unit.

---

### 🎯 Objective

* Reuse the generic quantity class created in UC3
* Support multiple measurement types (Length + Volume)
* Enable equality comparison between different volume units
* Maintain clean design aligned with SOLID and DRY principles

---

### 🧱 Design Approach

Instead of creating a new class for volume, UC4:

* Uses the same `Quantity` class
* Introduces a new enum: `VolumeUnit`
* Adds conversion extension methods
* Converts all volume values to a base unit before comparison

Base unit for volume → **Liter**

---

### 📐 Supported Volume Units

| Unit   | Conversion to Liter |
| ------ | ------------------- |
| Liter  | 1                   |
| Gallon | 3.78                |

---

### ⚙ Implementation Details

#### 1️⃣ VolumeUnit Enum

Represents supported volume units.

#### 2️⃣ VolumeUnitExtensions

Provides conversion factor to base unit (Liter).

#### 3️⃣ Generic Quantity Reuse

The existing equality logic works for volume without duplication.

---

### ✅ Example Scenarios

* 1 Gallon equals 3.78 Liters
* Same unit same value → equal
* Different values → not equal
* Null comparison → false

---

### 🧪 Test Cases Covered

* Liter to Liter equality
* Gallon to Liter equality
* Different volume values inequality
* Null comparison handling
* Cross-unit volume comparison

---

### 💡 Key Concepts Demonstrated

* Generic design
* DRY principle
* Open/Closed principle
* Extension methods
* Unit conversion via base unit
* Reusable equality logic

---

### 🚀 Outcome

UC4 successfully extends the system to support **Volume measurements** without modifying existing length logic, demonstrating scalable architecture.

The system can now support additional measurement types with minimal code changes.

---

