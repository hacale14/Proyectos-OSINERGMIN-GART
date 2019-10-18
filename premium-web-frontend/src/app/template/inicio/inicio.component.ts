import { Component , OnInit, ChangeDetectionStrategy} from '@angular/core';
import { FlatTreeControl } from '@angular/cdk/tree';
import { MatTreeFlatDataSource, MatTreeFlattener } from '@angular/material/tree';
import { MatTableDataSource } from '@angular/material/table';

export interface PeriodicElement {
  position: number;
  archivo: string;
  descripcion: string;
  fpublicacion: string;
  fregistro: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {position: 1, archivo: 'F_inf_file.zip', descripcion: 'Archivo Descarga', fpublicacion: '03/10/2019 10:39:00', fregistro: '03/10/2019 10:39:00'},
  {position: 1, archivo: 'F_inf_file1.zip', descripcion: 'Archivo Descarga 1', fpublicacion: '03/10/2019 10:39:00', fregistro: '03/10/2019 10:39:00'},
  {position: 1, archivo: 'F_inf_file2.zip', descripcion: 'Archivo Descarga 2', fpublicacion: '03/10/2019 10:39:00', fregistro: '03/10/2019 10:39:00'},
 
];

interface FoodNode {
  name: string;
  children?: FoodNode[];
}

const TREE_DATA: FoodNode[] = [
  {
    name: 'Publicación',
    children: [
      {
        name: 'Informe Mensual',
        children: [
          {
            name: 'InfOsinerming',
            children: [
              {
                name: 'Empresa',
                children: [
                  {name: '2017'},
                  {name: '2016'},
                  {name: '2015'},
                  {name: '2014'},
                ]
              },
            ]
          },
        ]
      }
    ]
  },
];

/** Flat node with expandable and level information */
interface ExampleFlatNode {
  expandable: boolean;
  name: string;
  level: number;
}

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class InicioComponent implements OnInit {

displayedColumns: string[] = ['position', 'archivo', 'descripcion', 'fpublicacion', 'fregistro'];
  dataSourceTable = new MatTableDataSource(ELEMENT_DATA);

  applyFilter(filterValue: string) {
    this.dataSourceTable.filter = filterValue.trim().toLowerCase();
  }

  private _transformer = (node: FoodNode, level: number) => {
    return {
      expandable: !!node.children && node.children.length > 0,
      name: node.name,
      level: level,
    };
  }

  treeControl = new FlatTreeControl<ExampleFlatNode>(
      node => node.level, node => node.expandable);

  treeFlattener = new MatTreeFlattener(
      this._transformer, node => node.level, node => node.expandable, node => node.children);

  dataSource = new MatTreeFlatDataSource(this.treeControl, this.treeFlattener);

  constructor() {
    this.dataSource.data = TREE_DATA;
  }

  hasChild = (_: number, node: ExampleFlatNode) => node.expandable;

  ngOnInit() {
  }

}
