import { Component, Inject } from '@angular/core';
import { DoughnutService } from './doughnut-tree.service';
import { Node } from '../Dto/Node';
import { TreeNode } from './doughnut-node.component';
import { Observable } from 'rxjs';


@Component({
    selector: 'app-home',
    templateUrl: './doughnut-tree.component.html',
    styleUrls: ['./doughnut-tree.component.css'],
    providers: [DoughnutService]
})

export class DoughnutComponent {
    node: Node;
    statement: String;
    answers: boolean[];
    constructor(private _doughnutService: DoughnutService) { }
    onPositiveClick(event: Event) {
        console.log('onPositiveClick!');
        this.postAnswers(true);
        //this.answers.push(true);
    }
    bindData(data: any) {
        if (data.isSuccess) {
            this.statement = data.data.statement;
            this.node = data.data.node;
            this.answers = data.data.answers;
        }
    }
    onNegativeClick(event: Event) {
        console.log('onNegativeClick!');
        this.postAnswers(false);
        //this.answers.push(false);
    }
    postAnswers(currentAns: boolean) {
        this._doughnutService.postAnswers(this.answers, currentAns).subscribe(
            data => {
                console.log(data)
                this.bindData(data);
                //this.node = data;
            }
        )
    }
    ngOnInit() {
        this._doughnutService.getStart().subscribe(
            data => {
                console.log(data)
                this.bindData(data);
                //this.node = data;
            }
        )
    }
}
