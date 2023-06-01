using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.Database;

public partial class CookbookDbContext : DbContext
{
    public CookbookDbContext()
    {
    }

    public CookbookDbContext(DbContextOptions<CookbookDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<FavoriteRecipe> FavoriteRecipes { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Measure> Measures { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<RecipeCategory> RecipeCategories { get; set; }

    public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    public virtual DbSet<RecipeStat> RecipeStats { get; set; }

    public virtual DbSet<RecipeStep> RecipeSteps { get; set; }

    public virtual DbSet<RecipeView> RecipeViews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=cookbook_db;Username=admin;Password=admin;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("client_pkey");

            entity.ToTable("client");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(5000)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(500)
                .HasColumnName("email");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(500)
                .HasColumnName("image_path");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(150)
                .HasColumnName("password");
        });

        modelBuilder.Entity<FavoriteRecipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("favorite_recipes_pkey");

            entity.ToTable("favorite_recipes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

            entity.HasOne(d => d.Client).WithMany(p => p.FavoriteRecipes)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("favorite_recipes_client_id_fkey");

            entity.HasOne(d => d.Recipe).WithMany(p => p.FavoriteRecipes)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("favorite_recipes_recipe_id_fkey");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ingredient_pkey");

            entity.ToTable("ingredient");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MeasureId).HasColumnName("measure_id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");

            entity.HasOne(d => d.Measure).WithMany(p => p.Ingredients)
                .HasForeignKey(d => d.MeasureId)
                .HasConstraintName("ingredient_measure_id_fkey");
        });

        modelBuilder.Entity<Measure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("measure_pkey");

            entity.ToTable("measure");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("recipe_pkey");

            entity.ToTable("recipe");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.Header)
                .HasMaxLength(50)
                .HasColumnName("header");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(500)
                .HasColumnName("image_path");
            entity.Property(e => e.SourceUrl)
                .HasMaxLength(500)
                .HasColumnName("source_url");

            entity.HasOne(d => d.Client).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("recipe_client_id_fkey");
        });

        modelBuilder.Entity<RecipeCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("recipe_categories_pkey");

            entity.ToTable("recipe_categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

            entity.HasOne(d => d.Category).WithMany(p => p.RecipeCategories)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("recipe_categories_category_id_fkey");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeCategories)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("recipe_categories_recipe_id_fkey");
        });

        modelBuilder.Entity<RecipeIngredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("recipe_ingredients_pkey");

            entity.ToTable("recipe_ingredients");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.RecipeIngredients)
                .HasForeignKey(d => d.IngredientId)
                .HasConstraintName("recipe_ingredients_ingredient_id_fkey");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeIngredients)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("recipe_ingredients_recipe_id_fkey");
        });

        modelBuilder.Entity<RecipeStat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("recipe_stats_pkey");

            entity.ToTable("recipe_stats");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Carbohydrates).HasColumnName("carbohydrates");
            entity.Property(e => e.CookingTime).HasColumnName("cooking_time");
            entity.Property(e => e.Fats).HasColumnName("fats");
            entity.Property(e => e.Kilocalories).HasColumnName("kilocalories");
            entity.Property(e => e.Portions)
                .HasDefaultValueSql("1")
                .HasColumnName("portions");
            entity.Property(e => e.Squirrels).HasColumnName("squirrels");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.RecipeStats)
                .HasForeignKey<RecipeStat>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recipe_stats_id_fkey");
        });

        modelBuilder.Entity<RecipeStep>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("recipe_step_pkey");

            entity.ToTable("recipe_step");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.Text).HasColumnName("text");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeSteps)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recipe_step_recipe_id_fkey");
        });

        modelBuilder.Entity<RecipeView>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("recipe_views_pkey");

            entity.ToTable("recipe_views");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Datetime)
                .HasDefaultValueSql("now()")
                .HasColumnName("datetime");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeViews)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("recipe_views_recipe_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}