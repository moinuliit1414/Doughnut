import { OrgData } from 'angular-org-chart/src/app/modules/org-chart/orgData';

export declare class DoughnutOrgData implements OrgData {
    name: string;
    type: string;
    children: DoughnutOrgData[];
    parent?: DoughnutOrgData;
    isSelected: boolean;
    constructor(orgStructure: string[], parent?: DoughnutOrgData);
}
