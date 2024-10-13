import { Component } from '@angular/core';
import { ApiService } from 'src/app/api.service';

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.css']
})
export class ItemListComponent {
  items: any[] = [];
  newItem: string = '';

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.fetchItems();
  }

  fetchItems(): void {
    this.apiService.getItems().subscribe((data) => {
      this.items = data;
    });
  }

  addItem(): void {
    const item = { name: this.newItem };
    this.apiService.addItem(item).subscribe((data) => {
      this.items.push(data);
      this.newItem = ''; 
    });
  }

  editItem(item: any): void {
    item.isEditing = true; 
  }

  saveItem(item: any): void {
    if (!item.name) return; 
    this.apiService.updateItem(item.id, item).subscribe(() => {
      item.isEditing = false; 
    });
  }

  deleteItem(id: number): void {
    this.apiService.deleteItem(id).subscribe(() => {
      this.items = this.items.filter(item => item.id !== id);
    });
  }
}