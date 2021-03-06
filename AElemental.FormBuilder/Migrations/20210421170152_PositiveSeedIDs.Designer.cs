// <auto-generated />
using System;
using AElemental.FormBuilder.Code;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AElemental.FormBuilder.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210421170152_PositiveSeedIDs")]
    partial class PositiveSeedIDs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("AElemental.FormBuilder.FormField", b =>
                {
                    b.Property<int>("FormFieldID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DropdownOptionCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Extension")
                        .HasColumnType("TEXT");

                    b.Property<string>("Field")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("FieldType")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Mandatory")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MaxLength")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("FormFieldID");

                    b.ToTable("FormFields");

                    b.HasData(
                        new
                        {
                            FormFieldID = 1,
                            Extension = "NAME",
                            Field = "Name",
                            FieldType = "Text",
                            Mandatory = true,
                            MaxLength = 100,
                            Section = "Basic info"
                        },
                        new
                        {
                            FormFieldID = 2,
                            Extension = "DESC",
                            Field = "Description",
                            FieldType = "Text",
                            Mandatory = false,
                            MaxLength = 400,
                            Section = "Basic info"
                        },
                        new
                        {
                            FormFieldID = 3,
                            Extension = "DT",
                            Field = "Creation Date",
                            FieldType = "Date",
                            Mandatory = true,
                            Section = "Basic info"
                        },
                        new
                        {
                            FormFieldID = 4,
                            Extension = "AMT",
                            Field = "Price",
                            FieldType = "Money",
                            Mandatory = true,
                            Section = "Price"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
