import { Component, OnInit } from '@angular/core';
import { LocationService } from "../../services/location.service";
import { UtilityService } from "../../services/utility.service";

@Component({
    selector: 'my-component',
    templateUrl: './provider-form.component.html'
})
export class ProviderFormComponent implements OnInit {
    regions: any[];
    utilities: any[];
    provider: {}

    constructor(private locationService: LocationService,
        private utilityService: UtilityService) { }

    ngOnInit() {
        this.locationService.getRegions().subscribe(regions => this.regions = regions);
        this.utilityService.getUtilities().subscribe(utilities => this.utilities = utilities);
    }
}
