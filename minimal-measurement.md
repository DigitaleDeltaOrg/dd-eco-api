# Minimal measurement

A minimal measurement should consist of at least the following properties:

- measurementdate: (when was the measurement taken)
- measurementlocation: (where was the measurement taken)
- unit: the unit that the measured value was expressed in. Examples are: n (amount, counted), kg (mass), cm (length), abundance (items/m2)
- quantity: the quantity that the measurement described. Examples are: height, length, concentration, acidity (pH), visibility, color
- parameter: the parameter that was measured. Examples: chloride, phytoplankton, oxygen. An example where parameter is not required, is quantity visibility
- measuredvalue: the measured value.
- compartment: the compartment in which the measurement took place, for instance surface water, air, shore

Units, quantities, parameters, measured values and compartments should be conform the [AQUO](https://www.aquo.nl/index.php/Categorie:Actueel) standard where possible.
Dates are in [ISO 8601 format](https://www.iso.org/iso-8601-date-and-time-format.html).

## Recommendations

Ecological measurements are not static. They can change over time, or be removed.
It is recommended that measurements (and all other entity that the provider exposes) to have a property named 'externalkey', which specifies an immutable 'id' or the entity, something consumers can depend on. It is recommended to _never_ use internal keys.
For measurements, it is also recommended to specify changedate, representing most recent date when the measurement underwent modification. This is very useful for synchronization purposes, where data gets transported to, for instance, a data lake.
Another recommended feature would be to have a service that lists the items (by their 'externalkey') that have been removed since a specific time, also for synchronization purposes.

## Beyond minimal measurements

Minimal measurements often do not contain enough information. Therefor, the properties are not limited to the fields described above.

At times, measurements can not be expressed in a numeric value. Example: odor, or the Braun-Blanquet scale.
In those cases, classifiedvalue can be beneficial:

- classifiedvalue: this represents, a value associated with a quantity when a numeric representation is not possible of feasible. For instance, in the case of quantity color this value could be YELLOW.

The value that was measured does not always represent the value that needs to be reported. Example: it is not feasible for a laboratory to examine a sample container (i.e. 1 liter) under a microscope. Therefor, only a small sample is taken from the container and examined. Then the measured value is used to calculate the value for the total volume. In that case calculatedvalue can be used.

- calculatedvalue: outcome of a calculation where measuredvalue is part of the calculation.

The properties of a measurement do not need to be limited singular date, string or numeric valued. It is also possible to use arrays and key-value pairs.
Examples:

- Describe which devices are used for sampling the measurements.
- Store properties seen with the specific measurements (life-stage, gender, length-class) with a single measurement, without to add specific columns when most of the data is optional.
