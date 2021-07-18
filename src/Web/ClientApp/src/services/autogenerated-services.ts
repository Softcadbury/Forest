/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.11.3.0 (NJsonSchema v10.4.4.0 (Newtonsoft.Json v10.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming

export class Client {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        this.http = http ? http : <any>window;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    /**
     * @return Success
     */
    trees(uuid: string): Promise<TreeViewModel> {
        let url_ = this.baseUrl + "/api/trees/{uuid}";
        if (uuid === undefined || uuid === null)
            throw new Error("The parameter 'uuid' must be defined.");
        url_ = url_.replace("{uuid}", encodeURIComponent("" + uuid));
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processTrees(_response);
        });
    }

    protected processTrees(response: Response): Promise<TreeViewModel> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = TreeViewModel.fromJS(resultData200);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<TreeViewModel>(<any>null);
    }

    /**
     * @param body (optional) 
     * @return Success
     */
    trees2(uuid: string, body: TreeViewModelPut | undefined): Promise<Tree> {
        let url_ = this.baseUrl + "/api/trees/{uuid}";
        if (uuid === undefined || uuid === null)
            throw new Error("The parameter 'uuid' must be defined.");
        url_ = url_.replace("{uuid}", encodeURIComponent("" + uuid));
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_ = <RequestInit>{
            body: content_,
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processTrees2(_response);
        });
    }

    protected processTrees2(response: Response): Promise<Tree> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = Tree.fromJS(resultData200);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<Tree>(<any>null);
    }

    /**
     * @return Success
     */
    trees3(uuid: string): Promise<void> {
        let url_ = this.baseUrl + "/api/trees/{uuid}";
        if (uuid === undefined || uuid === null)
            throw new Error("The parameter 'uuid' must be defined.");
        url_ = url_.replace("{uuid}", encodeURIComponent("" + uuid));
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "DELETE",
            headers: {
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processTrees3(_response);
        });
    }

    protected processTrees3(response: Response): Promise<void> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            return;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<void>(<any>null);
    }

    /**
     * @return Success
     */
    treesAll(): Promise<Tree[]> {
        let url_ = this.baseUrl + "/api/trees";
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processTreesAll(_response);
        });
    }

    protected processTreesAll(response: Response): Promise<Tree[]> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (Array.isArray(resultData200)) {
                result200 = [] as any;
                for (let item of resultData200)
                    result200!.push(Tree.fromJS(item));
            }
            else {
                result200 = <any>null;
            }
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<Tree[]>(<any>null);
    }

    /**
     * @param body (optional) 
     * @return Success
     */
    trees4(body: TreeViewModelPost | undefined): Promise<TreeViewModel> {
        let url_ = this.baseUrl + "/api/trees";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_ = <RequestInit>{
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processTrees4(_response);
        });
    }

    protected processTrees4(response: Response): Promise<TreeViewModel> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = TreeViewModel.fromJS(resultData200);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<TreeViewModel>(<any>null);
    }
}

export class TreeViewModel implements ITreeViewModel {
    uuid?: string;
    creationDate?: Date;
    label?: string | undefined;

    constructor(data?: ITreeViewModel) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.uuid = _data["uuid"];
            this.creationDate = _data["creationDate"] ? new Date(_data["creationDate"].toString()) : <any>undefined;
            this.label = _data["label"];
        }
    }

    static fromJS(data: any): TreeViewModel {
        data = typeof data === 'object' ? data : {};
        let result = new TreeViewModel();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["uuid"] = this.uuid;
        data["creationDate"] = this.creationDate ? this.creationDate.toISOString() : <any>undefined;
        data["label"] = this.label;
        return data; 
    }
}

export interface ITreeViewModel {
    uuid?: string;
    creationDate?: Date;
    label?: string | undefined;
}

export class TreeViewModelPut implements ITreeViewModelPut {
    label!: string;

    constructor(data?: ITreeViewModelPut) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.label = _data["label"];
        }
    }

    static fromJS(data: any): TreeViewModelPut {
        data = typeof data === 'object' ? data : {};
        let result = new TreeViewModelPut();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["label"] = this.label;
        return data; 
    }
}

export interface ITreeViewModelPut {
    label: string;
}

export class Node implements INode {
    uuid?: string;
    creationDate?: Date;
    tree?: Tree;
    treeId?: string;
    label?: string | undefined;

    constructor(data?: INode) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.uuid = _data["uuid"];
            this.creationDate = _data["creationDate"] ? new Date(_data["creationDate"].toString()) : <any>undefined;
            this.tree = _data["tree"] ? Tree.fromJS(_data["tree"]) : <any>undefined;
            this.treeId = _data["treeId"];
            this.label = _data["label"];
        }
    }

    static fromJS(data: any): Node {
        data = typeof data === 'object' ? data : {};
        let result = new Node();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["uuid"] = this.uuid;
        data["creationDate"] = this.creationDate ? this.creationDate.toISOString() : <any>undefined;
        data["tree"] = this.tree ? this.tree.toJSON() : <any>undefined;
        data["treeId"] = this.treeId;
        data["label"] = this.label;
        return data; 
    }
}

export interface INode {
    uuid?: string;
    creationDate?: Date;
    tree?: Tree;
    treeId?: string;
    label?: string | undefined;
}

export class Tree implements ITree {
    uuid?: string;
    creationDate?: Date;
    label?: string | undefined;
    nodes?: Node[] | undefined;

    constructor(data?: ITree) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.uuid = _data["uuid"];
            this.creationDate = _data["creationDate"] ? new Date(_data["creationDate"].toString()) : <any>undefined;
            this.label = _data["label"];
            if (Array.isArray(_data["nodes"])) {
                this.nodes = [] as any;
                for (let item of _data["nodes"])
                    this.nodes!.push(Node.fromJS(item));
            }
        }
    }

    static fromJS(data: any): Tree {
        data = typeof data === 'object' ? data : {};
        let result = new Tree();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["uuid"] = this.uuid;
        data["creationDate"] = this.creationDate ? this.creationDate.toISOString() : <any>undefined;
        data["label"] = this.label;
        if (Array.isArray(this.nodes)) {
            data["nodes"] = [];
            for (let item of this.nodes)
                data["nodes"].push(item.toJSON());
        }
        return data; 
    }
}

export interface ITree {
    uuid?: string;
    creationDate?: Date;
    label?: string | undefined;
    nodes?: Node[] | undefined;
}

export class TreeViewModelPost implements ITreeViewModelPost {
    label!: string;

    constructor(data?: ITreeViewModelPost) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.label = _data["label"];
        }
    }

    static fromJS(data: any): TreeViewModelPost {
        data = typeof data === 'object' ? data : {};
        let result = new TreeViewModelPost();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["label"] = this.label;
        return data; 
    }
}

export interface ITreeViewModelPost {
    label: string;
}

export class ApiException extends Error {
    message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isApiException = true;

    static isApiException(obj: any): obj is ApiException {
        return obj.isApiException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): any {
    if (result !== null && result !== undefined)
        throw result;
    else
        throw new ApiException(message, status, response, headers, null);
}