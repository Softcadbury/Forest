/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.15.5.0 (NJsonSchema v10.6.6.0 (Newtonsoft.Json v9.0.0.0)) (http://NSwag.org)
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
    resourcesGet(): Promise<Resources> {
        let url_ = this.baseUrl + "/api/resources";
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processResourcesGet(_response);
        });
    }

    protected processResourcesGet(response: Response): Promise<Resources> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = Resources.fromJS(resultData200);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<Resources>(<any>null);
    }

    /**
     * @return Success
     */
    treeGet(treeId: string): Promise<Tree> {
        let url_ = this.baseUrl + "/api/trees/{treeId}";
        if (treeId === undefined || treeId === null)
            throw new Error("The parameter 'treeId' must be defined.");
        url_ = url_.replace("{treeId}", encodeURIComponent("" + treeId));
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processTreeGet(_response);
        });
    }

    protected processTreeGet(response: Response): Promise<Tree> {
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
     * @param body (optional) 
     * @return Success
     */
    treeUpdate(treeId: string, body: TreePut | undefined): Promise<Tree> {
        let url_ = this.baseUrl + "/api/trees/{treeId}";
        if (treeId === undefined || treeId === null)
            throw new Error("The parameter 'treeId' must be defined.");
        url_ = url_.replace("{treeId}", encodeURIComponent("" + treeId));
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
            return this.processTreeUpdate(_response);
        });
    }

    protected processTreeUpdate(response: Response): Promise<Tree> {
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
    treeDelete(treeId: string): Promise<void> {
        let url_ = this.baseUrl + "/api/trees/{treeId}";
        if (treeId === undefined || treeId === null)
            throw new Error("The parameter 'treeId' must be defined.");
        url_ = url_.replace("{treeId}", encodeURIComponent("" + treeId));
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "DELETE",
            headers: {
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processTreeDelete(_response);
        });
    }

    protected processTreeDelete(response: Response): Promise<void> {
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
    treeGetAll(): Promise<Tree[]> {
        let url_ = this.baseUrl + "/api/trees";
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processTreeGetAll(_response);
        });
    }

    protected processTreeGetAll(response: Response): Promise<Tree[]> {
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
    treeCreate(body: TreePost | undefined): Promise<Tree> {
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
            return this.processTreeCreate(_response);
        });
    }

    protected processTreeCreate(response: Response): Promise<Tree> {
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
    treeNodeGet(treeId: string, nodeId: string): Promise<Node> {
        let url_ = this.baseUrl + "/api/trees/{treeId}/nodes/{nodeId}";
        if (treeId === undefined || treeId === null)
            throw new Error("The parameter 'treeId' must be defined.");
        url_ = url_.replace("{treeId}", encodeURIComponent("" + treeId));
        if (nodeId === undefined || nodeId === null)
            throw new Error("The parameter 'nodeId' must be defined.");
        url_ = url_.replace("{nodeId}", encodeURIComponent("" + nodeId));
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processTreeNodeGet(_response);
        });
    }

    protected processTreeNodeGet(response: Response): Promise<Node> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = Node.fromJS(resultData200);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<Node>(<any>null);
    }

    /**
     * @return Success
     */
    treeNodeGetAll(treeId: string): Promise<Node[]> {
        let url_ = this.baseUrl + "/api/trees/{treeId}/nodes";
        if (treeId === undefined || treeId === null)
            throw new Error("The parameter 'treeId' must be defined.");
        url_ = url_.replace("{treeId}", encodeURIComponent("" + treeId));
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processTreeNodeGetAll(_response);
        });
    }

    protected processTreeNodeGetAll(response: Response): Promise<Node[]> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (Array.isArray(resultData200)) {
                result200 = [] as any;
                for (let item of resultData200)
                    result200!.push(Node.fromJS(item));
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
        return Promise.resolve<Node[]>(<any>null);
    }

    /**
     * @param body (optional) 
     * @return Success
     */
    treeNodeCreate(treeId: string, body: NodePost | undefined): Promise<Node> {
        let url_ = this.baseUrl + "/api/trees/{treeId}/nodes";
        if (treeId === undefined || treeId === null)
            throw new Error("The parameter 'treeId' must be defined.");
        url_ = url_.replace("{treeId}", encodeURIComponent("" + treeId));
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
            return this.processTreeNodeCreate(_response);
        });
    }

    protected processTreeNodeCreate(response: Response): Promise<Node> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = Node.fromJS(resultData200);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<Node>(<any>null);
    }

    /**
     * @return Success
     */
    treeNodeGetPrettyPrint(treeId: string): Promise<string> {
        let url_ = this.baseUrl + "/api/trees/{treeId}/nodes/prettyPrint";
        if (treeId === undefined || treeId === null)
            throw new Error("The parameter 'treeId' must be defined.");
        url_ = url_.replace("{treeId}", encodeURIComponent("" + treeId));
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processTreeNodeGetPrettyPrint(_response);
        });
    }

    protected processTreeNodeGetPrettyPrint(response: Response): Promise<string> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = resultData200 !== undefined ? resultData200 : <any>null;
    
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<string>(<any>null);
    }

    /**
     * @param nodeId (optional) 
     * @param body (optional) 
     * @return Success
     */
    treeNodeUpdate(treeId: string, nodeId: string | undefined, id: string, body: NodePut | undefined): Promise<Node> {
        let url_ = this.baseUrl + "/api/trees/{treeId}/nodes/{id}?";
        if (treeId === undefined || treeId === null)
            throw new Error("The parameter 'treeId' must be defined.");
        url_ = url_.replace("{treeId}", encodeURIComponent("" + treeId));
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        if (nodeId === null)
            throw new Error("The parameter 'nodeId' cannot be null.");
        else if (nodeId !== undefined)
            url_ += "nodeId=" + encodeURIComponent("" + nodeId) + "&";
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
            return this.processTreeNodeUpdate(_response);
        });
    }

    protected processTreeNodeUpdate(response: Response): Promise<Node> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = Node.fromJS(resultData200);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<Node>(<any>null);
    }

    /**
     * @param nodeId (optional) 
     * @return Success
     */
    treeNodeDelete(treeId: string, nodeId: string | undefined, id: string): Promise<void> {
        let url_ = this.baseUrl + "/api/trees/{treeId}/nodes/{id}?";
        if (treeId === undefined || treeId === null)
            throw new Error("The parameter 'treeId' must be defined.");
        url_ = url_.replace("{treeId}", encodeURIComponent("" + treeId));
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        if (nodeId === null)
            throw new Error("The parameter 'nodeId' cannot be null.");
        else if (nodeId !== undefined)
            url_ += "nodeId=" + encodeURIComponent("" + nodeId) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "DELETE",
            headers: {
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processTreeNodeDelete(_response);
        });
    }

    protected processTreeNodeDelete(response: Response): Promise<void> {
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
}

export class Node implements INode {
    id?: string;
    creationDate?: Date;
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
            this.id = _data["id"];
            this.creationDate = _data["creationDate"] ? new Date(_data["creationDate"].toString()) : <any>undefined;
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
        data["id"] = this.id;
        data["creationDate"] = this.creationDate ? this.creationDate.toISOString() : <any>undefined;
        data["label"] = this.label;
        return data;
    }
}

export interface INode {
    id?: string;
    creationDate?: Date;
    label?: string | undefined;
}

export class NodePost implements INodePost {
    label!: string;

    constructor(data?: INodePost) {
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

    static fromJS(data: any): NodePost {
        data = typeof data === 'object' ? data : {};
        let result = new NodePost();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["label"] = this.label;
        return data;
    }
}

export interface INodePost {
    label: string;
}

export class NodePut implements INodePut {
    label!: string;

    constructor(data?: INodePut) {
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

    static fromJS(data: any): NodePut {
        data = typeof data === 'object' ? data : {};
        let result = new NodePut();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["label"] = this.label;
        return data;
    }
}

export interface INodePut {
    label: string;
}

export class Resources implements IResources {

    constructor(data?: IResources) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
    }

    static fromJS(data: any): Resources {
        data = typeof data === 'object' ? data : {};
        let result = new Resources();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        return data;
    }
}

export interface IResources {
}

export class Tree implements ITree {
    id?: string;
    creationDate?: Date;
    label?: string | undefined;

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
            this.id = _data["id"];
            this.creationDate = _data["creationDate"] ? new Date(_data["creationDate"].toString()) : <any>undefined;
            this.label = _data["label"];
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
        data["id"] = this.id;
        data["creationDate"] = this.creationDate ? this.creationDate.toISOString() : <any>undefined;
        data["label"] = this.label;
        return data;
    }
}

export interface ITree {
    id?: string;
    creationDate?: Date;
    label?: string | undefined;
}

export class TreePost implements ITreePost {
    label!: string;

    constructor(data?: ITreePost) {
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

    static fromJS(data: any): TreePost {
        data = typeof data === 'object' ? data : {};
        let result = new TreePost();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["label"] = this.label;
        return data;
    }
}

export interface ITreePost {
    label: string;
}

export class TreePut implements ITreePut {
    label!: string;

    constructor(data?: ITreePut) {
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

    static fromJS(data: any): TreePut {
        data = typeof data === 'object' ? data : {};
        let result = new TreePut();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["label"] = this.label;
        return data;
    }
}

export interface ITreePut {
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