﻿using System;
using System.Collections.Generic;

using UML=TSF.UmlToolingFramework.UML;

namespace TSF.UmlToolingFramework.Wrappers.EA {
  public class ParameterReturnType : Parameter {
    internal global::EA.Method wrappedOperation {
      get { return this._owner.wrappedOperation; }
    }
    
    internal Operation _owner;
    
    public ParameterReturnType( Model model, Operation operation) 
      : base(model)
    {
      this._owner = operation;
    }
    
    public override UML.Classes.Kernel.ParameterDirectionKind direction {
      get { return UML.Classes.Kernel.ParameterDirectionKind._return; }
      set { throw new NotImplementedException(); }
    }
    
    public override String _default {
      get { throw new NotImplementedException(); }
      set { throw new NotImplementedException(); }
    }
    
    public override UML.Classes.Kernel.ValueSpecification defaultValue {
      get { throw new NotImplementedException(); }
      set { throw new NotImplementedException(); }
    }
   
    public override bool isOrdered {
      get { throw new NotImplementedException(); }
      set { throw new NotImplementedException(); }
    }
    
    public override bool isUnique {
      get { throw new NotImplementedException(); }
      set { throw new NotImplementedException(); }
    }
    
    public override UML.Classes.Kernel.UnlimitedNatural upper {
      get { throw new NotImplementedException(); }
      set { throw new NotImplementedException(); }
    }
    
    public override int lower {
      get { throw new NotImplementedException(); }
      set { throw new NotImplementedException(); }
    }
    
    public override UML.Classes.Kernel.ValueSpecification upperValue {
      get { throw new NotImplementedException(); }
      set { throw new NotImplementedException(); }
    }
    public override UML.Classes.Kernel.ValueSpecification lowerValue {
      get { throw new NotImplementedException(); }
      set { throw new NotImplementedException(); }
    }
    
    public override UML.Classes.Kernel.Type type {
      get {
        // for some strange reason the classifierid of the parameter is a 
        // string, where all other id the the EA API are integers.
        int ClassifierID;
        UML.Classes.Kernel.Type type = null;
        if (int.TryParse(this.wrappedOperation.ClassifierID,out ClassifierID))
        {
           	type = this.model.getElementWrapperByID(ClassifierID) as UML.Classes.Kernel.Type;
        }
        // check if the type is defined as an element in the model.
        if( type == null ) {
          // no element, create primitive type based on the name of the 
          // returntype
          type = this.model.factory.createPrimitiveType
            ( this.wrappedOperation.ReturnType );
        }
        return type;
      }
      set { throw new NotImplementedException(); }
    }
    
    public override String name {
      get { return "returntype of " + this.operation.name; }
      set { throw new NotImplementedException(); }
    }
    public override UML.Classes.Kernel.VisibilityKind visibility {
      get { return this._owner.visibility; }
      set { throw new NotImplementedException(); }
    }
    
    public override String qualifiedName {
      get { throw new NotImplementedException(); }
      set { throw new NotImplementedException(); }
    }
    
    public override UML.Classes.Kernel.Namespace owningNamespace {
      get { throw new NotImplementedException(); }
      set { throw new NotImplementedException(); }
    }
    
    public override HashSet<UML.Classes.Kernel.Element> ownedElements {
      get { return new HashSet<UML.Classes.Kernel.Element>(); }
      set { /* do nothing */ }
    }

    public override HashSet<UML.Classes.Kernel.Comment> ownedComments {
      get { throw new NotImplementedException(); }
      set { throw new NotImplementedException(); }
    }
    
    public override UML.Classes.Kernel.Element owner {
      get { return this._owner; }
      set { throw new NotImplementedException(); }
    }
    
    public override HashSet<UML.Profiles.Stereotype> stereotypes {
      get { return new HashSet<UML.Profiles.Stereotype>(); }
      set { /* do nothing, no stereotypes on return types */ }
    }
    

    // save the return type to the case tool.
    // this return type is implemented as a primitive or as a parameter in EA
    internal override void saveElement(){
      // saving the parent operation saves the parameters as well.
      // now we don't have to worry wether this returntype is modelled in EA 
      // as a parameter or as the type of the operation.
      this._owner.saveElement();
    }
    
    public override String notes {
      get { return String.Empty; }
      set { /* do nothing, returntypes do not have comments in EA */ }
    }
  	

  	
	public override TSF.UmlToolingFramework.UML.UMLItem getItemFromRelativePath(List<string> relativePath)
	{
		return null;
	}
  }
}
