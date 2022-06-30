﻿using System;
using System.ComponentModel.DataAnnotations;
using AElemental.Components;

namespace AElemental.Documentation.Data;

public class InteractiveStarship
{
    [AeFormIgnore] private int ID { get; set; } = 1;

    [Required]
    [StringLength(16, ErrorMessage = "Identifier too long (16 character limit).")]
    [AeLabel(placeholder: "Starship identifier...")]
    public string Identifier { get; set; }

    [Required]
    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid Email Address")]
    [StringLength(20, ErrorMessage = "Identifier too long (16 character limit).")]
    [AeLabel(placeholder: "Enter Email...")]
    public string CaptainsEmail { get; set; }

    [Editable(false)]
    [AeLabel(size: 100, placeholder: "Describe your starship including crew size")]
    public string Description { get; set; }

    [Required] [AeLabel(isDropDown: true)] public string Classification { get; set; }

    [Required] [AeLabel(isDropDown: true)] public string SubClassification { get; set; }

    [Range(1, 100000, ErrorMessage = "Accommodation invalid (1-100000).")]
    [AeLabel("Maximum Accomodation")]
    public int MaximumAccommodation { get; set; }

    [AeLabel("Maintenance Cost")]
    [Editable(false)]
    [DisplayFormat(DataFormatString = "c")]
    public double MaintenanceCost => MaximumAccommodation * 100;

    [Required]
    [Range(typeof(bool), "true", "true", ErrorMessage = "This form disallows unapproved ships.")]
    [AeLabel("Validated Design")]
    public bool IsValidatedDesign { get; set; }

    [Required]
    [AeLabel("Production Date")]
    public DateTime ProductionDate { get; set; }

    public DateTime? FirstFlightDate { get; set; }

    public int? SubLightEngines { get; set; }
}