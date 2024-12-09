import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ProductService } from 'src/app/Services/product.service';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-product-management',
  templateUrl: './product-management.component.html',
  styleUrls: ['./product-management.component.css']
})
export class ProductManagementComponent implements OnInit {
  productForm: FormGroup;
  successMessage: string = '';
  errorMessage: string = '';
  products: any[] = [];
  editingProduct: any | null = null; // Track the product being edited
  userId: any;


  constructor(private fb: FormBuilder, private router: Router, private productService: ProductService, private userService:UserService) {
    this.productForm = this.fb.group({
      productName: ['', Validators.required],
      make: ['', Validators.required],
      model: ['', Validators.required],
      cost: ['', [Validators.required, Validators.min(0)]],
      createdDate: [{ value: new Date().toLocaleDateString(), disabled: true }]
    });
  }


  ngOnInit(): void {
    this.userId = this.userService.getUserId(); // Get the logged-in user's ID

    if (this.userId) {
      this.loadProducts();
    } else {
      console.error('User is not logged in.');
    }
  }


  loadProducts() {
    // const existingProducts = localStorage.getItem('products');
    // this.products = existingProducts ? JSON.parse(existingProducts) : [];
    this.productService.getAllProducts(this.userId).subscribe(
      (response) => {
        this.products = response.products;
      },
      (error) => {
        console.error('Error fetching products:', error);
      });
    };
     


  onSubmit(): void {
    if (this.productForm.valid) {
      if (this.editingProduct) {
        // If editing, update the product
        const updatedProduct = {
          ...this.editingProduct, // Keep existing productId and userId
          ...this.productForm.getRawValue() // Get form values, including createdDate
        };

        this.productService.updateProduct(updatedProduct).subscribe(
          (response) => {
            alert(this.successMessage = 'Product updated successfully!');
            this.resetForm(); // Reset the form after updating
            this.loadProducts(); // Reload products
          },
          (error) => {
            console.error('Error updating product:', error);
            this.errorMessage = 'Failed to update product.';
          }
        );
      } else {
        // If not editing, add a new product
        this.productService.addProduct(this.productForm.value).subscribe(
          (response) => {
            alert(this.successMessage = 'Product added successfully!');
            this.resetForm(); // Reset the form after adding
            this.loadProducts(); // Reload products
          },
          (error) => {
            console.error('Error adding product:', error);
            this.errorMessage = 'Failed to add product.';
          }
        );
      }
    }
    
     else {
      this.errorMessage = 'Please fill in all required fields correctly.';
      this.successMessage = '';
    }
  }


  onEdit(product: any): void {
    this.editingProduct = product; // Set the product to be edited
    this.productForm.patchValue({
      productName: product.productName,
      make: product.make,
      model: product.model,
      cost: product.cost,
      createdDate: product.createdDate // Display created date (read-only)
    });
  }
  resetForm(): void {
    this.editingProduct = null;
    this.productForm.reset();
    this.productForm.patchValue({ createdDate: '' }); // Reset the createdDate field
  }

  // onDelete(product: any): void {
  //   this.products = this.products.filter(p => p.productName !== product.productName);
  //   localStorage.setItem('products', JSON.stringify(this.products));
  //   this.successMessage = 'Product deleted successfully!';
  //   this.loadProducts();
  // }
  onDelete(product: any): void {
    if (confirm('Are you sure you want to delete this product?')) {
      this.productService.deleteProduct(product.productId).subscribe(
        (response) => {
          this.successMessage = 'Product deleted successfully!';
          this.loadProducts(); // Reload the products list after deletion
        },
        (error) => {
          console.error('Error deleting product:', error);
          this.errorMessage = 'Failed to delete product.';
        }
      );
    }
  }
}



