import { Component, forwardRef, Input } from '@angular/core';
import { Node } from '../Dto/Node';

@Component({
    selector: 'tree-node',
    template: `
  <div _ngcontent-ng-cli-universal-c1 class="{{node?.isSelected ? 'selected' : 'notselected'}} {{(node.leafY==null && node.leafN==null)?'leaf':''}} nodecontent ">{{node?.statement}}</div>
  <ul _ngcontent-ng-cli-universal-c1>
    <li _ngcontent-ng-cli-universal-c1 class="node" *ngIf="node.leafY">
      <div _ngcontent-ng-cli-universal-c1 >Yes</div>
      <tree-node [node]="node.leafY" ></tree-node>
    </li>
    <li _ngcontent-ng-cli-universal-c1 class="node" *ngIf="node.leafN">
      <div _ngcontent-ng-cli-universal-c1 >No</div>
      <tree-node [node]="node.leafN" ></tree-node>
    </li>
  </ul>
`
})

export class TreeNode {
    @Input() node: Node;
}
