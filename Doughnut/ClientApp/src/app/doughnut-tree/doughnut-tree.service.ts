import { Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Node } from '../Dto/Node';
import { DoughnutOrgData } from '../Dto/DoughnutOrgData';
//import { OrgData } from 'angular-org-chart/src/app/modules/org-chart/orgData';



export class DoughnutService {
    private _baseUrl: string;
    private _http: HttpClient;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this._baseUrl = baseUrl;
        this._http = http;
    }

    //mapToOrgData(noad: Node): DoughnutOrgData {
    //    let orgData: DoughnutOrgData;
    //    if (noad.LeafN != null) {
    //        orgData.children.push(this.mapToOrgData(noad.LeafN))
    //    }
    //    if (noad.LeafY != null) {
    //        orgData.children.push(this.mapToOrgData(noad.LeafY))
    //    }
    //    orgData.name = noad.Statement;
    //    return orgData;
    //}
    //Post current answer with previous answer.
    postAnswers(answers: boolean[], currentAns: boolean): Observable<any> {
        answers.push(currentAns);
        return this._http.post(this._baseUrl + 'DoughnutDecision', { "answers": answers});
    }
    getStart(): Observable<any> {
        return this._http.get(this._baseUrl + 'DoughnutDecision');
    }
}
